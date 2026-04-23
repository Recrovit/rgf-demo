using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recrovit.AspNetCore.Authentication.OpenIdConnect.Authentication;
using Recrovit.AspNetCore.Authentication.OpenIdConnect.Configuration;
using RGF.DemoApp.Client.Models;
using RGF.DemoApp.Features.UserInfo;
using RGF.DemoApp.Tests.Testing;
using Xunit;

namespace RGF.DemoApp.Tests.UserInfo;

public sealed class UserInfoEndpointsIntegrationTests
{
    [Fact]
    public async Task GetUserInfo_ReturnsMappedProfileForAuthenticatedRequest()
    {
        var downstreamHandler = new StubHandler(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(new
            {
                sub = "user-123",
                name = "Demo User",
                email = "demo@example.com",
                roles = new[] { "Reader" },
                tid = "tenant-1"
            })
        });
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = Environments.Development
        });

        builder.WebHost.UseTestServer();
        builder.Services.AddAuthentication("Test")
            .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("Test", static _ => { });
        builder.Services.AddAuthorization();
        builder.Services.AddScoped(_ => new UserInfoDownstreamClient(
            new HttpClient(downstreamHandler, disposeHandler: false)
            {
                BaseAddress = new Uri("https://graph.example.test/")
            },
            new StubDownstreamUserTokenProvider(),
            new DownstreamApiCatalog(new Dictionary<string, DownstreamApiDefinition>(StringComparer.OrdinalIgnoreCase)
            {
                [UserInfoDownstreamClient.DownstreamApiName] = new()
                {
                    BaseUrl = "https://graph.example.test/",
                    RelativePath = "oidc/userinfo",
                    Scopes = ["openid", "profile", "email"]
                }
            })));
        builder.Services.AddScoped<UserInfoService>();

        await using var app = builder.Build();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapUserInfoEndpoints();

        await app.StartAsync(TestContext.Current.CancellationToken);

        using var client = app.GetTestClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test", "ok");

        using var response = await client.GetAsync("/api/userinfo", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var payload = await response.Content.ReadFromJsonAsync<UserInfoDto>(cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(payload);
        Assert.Equal("user-123", payload.Subject);
        Assert.Equal("Demo User", payload.Name);
        Assert.Equal("demo@example.com", payload.Email);
        Assert.Equal(["Reader"], payload.Roles);
        Assert.Equal(["tenant-1"], payload.AdditionalClaims["tid"]);
        Assert.Equal("https://graph.example.test/oidc/userinfo", downstreamHandler.LastRequest?.RequestUri?.ToString());
        Assert.Equal("Bearer", downstreamHandler.LastRequest?.Headers.Authorization?.Scheme);
        Assert.Equal("access-token", downstreamHandler.LastRequest?.Headers.Authorization?.Parameter);
    }

    private sealed class StubDownstreamUserTokenProvider : IDownstreamUserTokenProvider
    {
        public Task<string> GetAccessTokenAsync(
            System.Security.Claims.ClaimsPrincipal user,
            string downstreamApiName,
            CancellationToken cancellationToken)
            => Task.FromResult("access-token");
    }

    private sealed class StubHandler(HttpResponseMessage response) : HttpMessageHandler
    {
        public HttpRequestMessage? LastRequest { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequest = request;
            return Task.FromResult(response);
        }
    }
}
