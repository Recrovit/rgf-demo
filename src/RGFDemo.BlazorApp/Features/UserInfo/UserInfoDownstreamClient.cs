using Recrovit.AspNetCore.Authentication.OpenIdConnect.Authentication;
using Recrovit.AspNetCore.Authentication.OpenIdConnect.Configuration;
using RGF.DemoApp.Client.Models;
using System.Text.Json;
using System.Security.Claims;

namespace RGF.DemoApp.Features.UserInfo;

public sealed class UserInfoDownstreamClient(
    HttpClient httpClient,
    IDownstreamUserTokenProvider tokenProvider,
    DownstreamApiCatalog downstreamApiCatalog)
{
    public const string DownstreamApiName = "UserInfoApi";

    public async Task<UserInfoDto> GetUserInfoAsync(ClaimsPrincipal user, CancellationToken cancellationToken)
    {
        var downstreamApi = downstreamApiCatalog.GetRequired(DownstreamApiName);
        var accessToken = await tokenProvider.GetAccessTokenAsync(user, DownstreamApiName, cancellationToken);

        using var request = new HttpRequestMessage(HttpMethod.Get, downstreamApi.RelativePath);
        request.Headers.Authorization = new("Bearer", accessToken);

        using var response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);

        return UserInfoResponseParser.Parse(document.RootElement);
    }
}
