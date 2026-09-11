using NLog;
using NLog.Web;
using RGFDemo.WebAPI;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog(new NLogAspNetCoreOptions { IncludeScopes = true });

    // Add services to the container.
    //builder.Services.AddControllers();

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.AddRgf();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    if (LiveTestShutdown.IsEnabled(app.Environment.IsDevelopment(),
        Environment.GetEnvironmentVariable("RGF_RECROBY_LIVE_HOST_ID"), Console.IsInputRedirected))
    {
        _ = Task.Run(() => LiveTestShutdown.ListenAsync(Console.In, app.Lifetime));
    }

    await app.UseRgfAsync();

    app.MapControllers();

    app.Run();
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
