using System.Security.Claims;
using RGFDemo.BlazorApp.Client.Models;

namespace RGFDemo.BlazorApp.Features.UserInfo;

public sealed class UserInfoService(UserInfoDownstreamClient downstreamClient)
{
    public Task<UserInfoDto> GetUserInfoAsync(ClaimsPrincipal user, CancellationToken cancellationToken)
    {
        return downstreamClient.GetUserInfoAsync(user, cancellationToken);
    }
}
