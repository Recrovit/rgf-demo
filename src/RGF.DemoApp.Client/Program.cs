using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Recrovit.AspNetCore.Components.Routing.Configuration;
using Recrovit.RecroGridFramework.Client.Blazor;
using Recrovit.RecroGridFramework.Client.Blazor.SessionAuth;
using Recrovit.RecroGridFramework.Client.Blazor.UI;
using RGF.DemoApp.Client.Components;
using RGF.DemoApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

builder.Services.AddRgfBlazorSessionAuthClientServices(builder.Configuration, builder.HostEnvironment.BaseAddress);
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserInfoApiClient, UserInfoApiClient>();

builder.Services.AddRecrovitComponentRouting(options =>
{
    options.AddRouteAssembly(typeof(Program).Assembly);
    //options.AddRouteAssembly(typeof(Recrovit.RecroGridFramework.Client.Blazor.Components.RgfEntityComponent).Assembly);
});

var host = builder.Build();

await host.Services.InitializeRgfBlazorAsync();
await host.Services.InitializeRgfUIAsync();

RgfBlazorConfiguration.RegisterEntityComponent<ProductComponent>("RG_Product_1");
//RgfBlazorConfiguration.RegisterEntityComponent<OrderComponent>("RG_Orders_1");
RgfBlazorConfiguration.RegisterEntityComponent<OrderDetailsComponent>("RG_OrderDetails_1");

await host.RunAsync();
