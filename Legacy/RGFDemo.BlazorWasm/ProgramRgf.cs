using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Recrovit.RecroGridFramework.Client.Blazor;
using Recrovit.RecroGridFramework.Client.Blazor.UI;
using Syncfusion.Blazor;
using System.Reflection;

namespace RGFDemo.BlazorWasm;

public static class ProgramRgf
{
    public static WebAssemblyHostBuilder AddRgfServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddOidcAuthentication(options =>
        {
            var provider = builder.Configuration.GetValue<string>("Oidc:Provider", "Duende");
            builder.Configuration.Bind($"Oidc:{provider}:ProviderOptions", options.ProviderOptions);
        });

        var loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger<Program>();
        builder.Services.AddRgfBlazorWasmBearerServices(builder.Configuration, logger);

#if DevExpressEnabled
        builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5);
#endif
        builder.Services.AddScoped<Radzen.DialogService>();

        builder.Services.AddSyncfusionBlazor();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetValue<string>("Syncfusion:LicenseKey"));

#if TelerikEnabled
        builder.Services.AddTelerikBlazor();
#endif
        return builder;
    }

    public static async Task InitializeRgfAsync(this IServiceProvider serviceProvider)
    {
        await serviceProvider.InitializeRgfBlazorAsync();
        await serviceProvider.InitializeRgfUIAsync();
    }

    private static readonly Lazy<string> _version = new Lazy<string>(() => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()!.Version);

    public static string Version => _version.Value;
}
