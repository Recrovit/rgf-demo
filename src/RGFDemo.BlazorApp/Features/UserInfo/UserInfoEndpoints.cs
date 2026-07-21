using Recrovit.AspNetCore.Authentication.OpenIdConnect.Configuration;
using Recrovit.RecroGridFramework.Client.Blazor.SessionAuth.Proxy;
using Recrovit.RecroGridFramework.Client.Services;
using RGF.DemoApp.Client.Services;
using System.Security.Claims;

namespace RGF.DemoApp.Features.UserInfo;

public static class UserInfoEndpoints
{
    /// <summary>
    /// Registers application-specific downstream clients and services.
    /// </summary>
    public static IServiceCollection AddUserInfoServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient<UserInfoDownstreamClient, UserInfoDownstreamClient>((serviceProvider, client) =>
        {
            var api = serviceProvider.GetRequiredService<DownstreamApiCatalog>().GetRequired(UserInfoDownstreamClient.DownstreamApiName);
            client.BaseAddress = new Uri(api.BaseUrl);
        });
        services.AddScoped<UserInfoService>();

        services.AddHttpClient<IUserInfoApiClient, UserInfoApiClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(ApiService.BaseAddress);
        })
        .AddHttpMessageHandler<RgfServerProxyAuthCookieHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapUserInfoEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/userinfo", GetUserInfoAsync)
            .AsProxyEndpoint()
            .RequireAuthorization()
            .DisableAuthRedirects()
            .WithName("GetUserInfo")
            .WithSummary("Retrieves the RGF.Demo.IDP userinfo response on behalf of the user.");

        return endpoints;
    }

    private static async Task<IResult> GetUserInfoAsync(
        ClaimsPrincipal user,
        UserInfoService userInfoService,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await userInfoService.GetUserInfoAsync(user, cancellationToken);
            return TypedResults.Ok(result);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(
                title: "The active OIDC provider userinfo call failed.",
                detail: ex.Message,
                statusCode: StatusCodes.Status502BadGateway);
        }
    }
}
