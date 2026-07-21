using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using RGF.DemoApp.Client.Models;
using RGF.DemoApp.Client.Services;
using Xunit;

namespace RGF.DemoApp.Tests.UserInfo;

public sealed class UserInfoApiClientTests
{
    [Fact]
    public async Task GetAsync_ReturnsDtoFromHostEndpoint()
    {
        var handler = new StubHandler(new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(new UserInfoDto
            {
                Subject = "user-123",
                Name = "Demo User",
                Email = "demo@example.com",
                Roles = ["Reader"]
            })
        });
        using var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://host.example.test")
        };
        var client = new UserInfoApiClient(httpClient);

        var result = await client.GetAsync(TestContext.Current.CancellationToken);

        Assert.Equal("user-123", result.Subject);
        Assert.Equal("Demo User", result.Name);
        Assert.Equal("demo@example.com", result.Email);
        Assert.Equal(["Reader"], result.Roles);
        Assert.Equal("https://host.example.test/api/userinfo", handler.LastRequest?.RequestUri?.ToString());
    }

    [Theory]
    [InlineData(HttpStatusCode.Unauthorized)]
    [InlineData(HttpStatusCode.Forbidden)]
    public async Task GetAsync_ThrowsFriendlyMessage_WhenAccessIsDenied(HttpStatusCode statusCode)
    {
        using var httpClient = new HttpClient(new StubHandler(new HttpResponseMessage(statusCode)))
        {
            BaseAddress = new Uri("https://host.example.test")
        };
        var client = new UserInfoApiClient(httpClient);

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => client.GetAsync(TestContext.Current.CancellationToken));

        Assert.Contains("no permission", exception.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Contains(statusCode.ToString(), exception.Message, StringComparison.Ordinal);
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
