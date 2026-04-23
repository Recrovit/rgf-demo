using System.Net;
using System.Net.Http.Json;
using RGF.DemoApp.Client.Models;

namespace RGF.DemoApp.Client.Services;

public sealed class UserInfoApiClient(HttpClient httpClient) : IUserInfoApiClient
{
    public async Task<UserInfoDto> GetAsync(CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync("/api/userinfo", cancellationToken);

        if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
        {
            throw new InvalidOperationException($"No permission to access the endpoint. {response.StatusCode}");
        }

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<UserInfoDto>(cancellationToken: cancellationToken);
        return payload ?? throw new InvalidOperationException("The endpoint returned an empty payload.");
    }
}
