using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Web;
using Recrovit.AspNetCore.Authentication.OpenIdConnect.Configuration;
using Recrovit.AspNetCore.Components.Routing.Configuration;
using Recrovit.AspNetCore.Components.Routing.Models;
using Recrovit.RecroGridFramework.Client.Blazor;
using Recrovit.RecroGridFramework.Client.Blazor.Host.OpenIdConnect.Configuration;
using Recrovit.RecroGridFramework.Client.Blazor.UI;
using RGFDemo.BlazorApp.Client.Layout;
using RGFDemo.BlazorApp.Components;
using RGFDemo.BlazorApp.Features.UserInfo;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    if (builder.Environment.IsDevelopment())
    {
        var provider = builder.Configuration["Recrovit:OpenIdConnect:Provider"];
        if (provider != "Duende" && !string.IsNullOrWhiteSpace(provider))
        {
            builder.Configuration.AddUserSecrets(provider, reloadOnChange: true);
            Console.WriteLine("Authority: {0}", builder.Configuration[$"Recrovit:OpenIdConnect:Providers:{provider}:Authority"]);
        }
    }

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddRecrovitComponentRouting(options =>
    {
        options.AddRouteAssembly(typeof(App).Assembly);
        options.AddRouteAssembly(typeof(RGFDemo.BlazorApp.Client._Imports).Assembly);
        options.DefaultLayout = typeof(MainLayout);
        options.SetNotFoundPage(RecrovitRoutesKind.Host, typeof(RGFDemo.BlazorApp.Client.Pages.NotFound));
    });

    builder.AddRgfBlazorServerProxyOpenIdConnectRazorComponents();
    builder.AddRgfBlazorServerProxyOpenIdConnectHost();

    builder.Services.AddUserInfoServices(builder.Configuration);

    var enforceProductionReadiness = builder.IsRecrovitOpenIdConnectProductionReadinessEnforced();
    if (enforceProductionReadiness)
    {
        //dotnet tool install --global dotnet-sql-cache
        //dotnet sql-cache create "Server=(localdb)\mssqllocaldb;Database=RGFDemo;Trusted_Connection=True;TrustServerCertificate=True" dbo RgfOidcTokenCache

        var sqlServerCacheConnectionString = builder.Configuration.GetConnectionString("DistributedSqlServerCache");
        if (string.IsNullOrWhiteSpace(sqlServerCacheConnectionString))
        {
            throw new InvalidOperationException(
                "Distributed user token storage requires ConnectionStrings:DistributedSqlServerCache when production-readiness validation is enforced.");
        }

        builder.Services.RemoveAll<IDistributedCache>();
        builder.Services.AddDistributedSqlServerCache(options =>
        {
            options.ConnectionString = sqlServerCacheConnectionString;
            options.SchemaName = "dbo";
            options.TableName = "RgfOidcTokenCache";
        });
    }

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        builder.Configuration.AddUserSecrets<Program>();
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.MapRgfBlazorServerProxyOpenIdConnectEndpoints("/not-found");

    await app.Services.InitializeRgfBlazorServerAsync();
    await app.Services.InitializeRgfUIAsync(loadResources: false);

    app.MapRgfBlazorServerProxyOpenIdConnectComponents<App>(typeof(RGFDemo.BlazorApp.Client._Imports).Assembly);

    app.MapUserInfoEndpoints();

    await app.RunAsync();
}
catch (Exception exception) when (exception is not HostAbortedException)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
