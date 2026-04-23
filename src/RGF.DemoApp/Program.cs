using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Web;
using Recrovit.AspNetCore.Components.Routing.Configuration;
using Recrovit.AspNetCore.Components.Routing.Models;
using Recrovit.RecroGridFramework.Client.Blazor;
using Recrovit.RecroGridFramework.Client.Blazor.Host.OpenIdConnect.Configuration;
using Recrovit.RecroGridFramework.Client.Blazor.UI;
using RGF.DemoApp.Client.Layout;
using RGF.DemoApp.Components;
using RGF.DemoApp.Features.UserInfo;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddRecrovitComponentRouting(options =>
    {
        options.AddRouteAssembly(typeof(App).Assembly);
        options.AddRouteAssembly(typeof(RGF.DemoApp.Client._Imports).Assembly);
        options.DefaultLayout = typeof(MainLayout);
        options.SetNotFoundPage(RecrovitRoutesKind.Host, typeof(RGF.DemoApp.Client.Pages.NotFound));
    });

    builder.AddRgfBlazorServerProxyOpenIdConnectRazorComponents();
    builder.AddRgfBlazorServerProxyOpenIdConnectHost();

    builder.Services.AddUserInfoServices(builder.Configuration);

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
    
    //if (builder.Environment.IsProduction())
    //{
    //    var sqlServerCacheConnectionString = builder.Configuration.GetConnectionString("DistributedSqlServerCache");
    //    if (string.IsNullOrWhiteSpace(sqlServerCacheConnectionString))
    //    {
    //        throw new InvalidOperationException("Production requires ConnectionStrings:DistributedSqlServerCache for distributed user token storage.");
    //    }

    //    builder.Services.RemoveAll<IDistributedCache>();
    //    builder.Services.AddDistributedSqlServerCache(options =>
    //    {
    //        options.ConnectionString = sqlServerCacheConnectionString;
    //        options.SchemaName = "dbo";
    //        options.TableName = "OidcDistributedCache";
    //    });
    //}

    app.UseHttpsRedirection();

    app.MapRgfBlazorServerProxyOpenIdConnectEndpoints("/not-found");

    await app.Services.InitializeRgfBlazorServerAsync();
    await app.Services.InitializeRgfUIAsync(loadResources: false);

    app.MapRgfBlazorServerProxyOpenIdConnectComponents<App>(typeof(RGF.DemoApp.Client._Imports).Assembly);

    app.MapUserInfoEndpoints();

    await app.RunAsync();
}
catch (Exception exception)
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
