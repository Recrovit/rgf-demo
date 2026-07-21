using System.Security.Claims;
using RGF.DemoApp.Client.Models;

namespace RGF.DemoApp.Features.UserInfo;

public sealed class UserInfoService(UserInfoDownstreamClient downstreamClient)
{
    public Task<UserInfoDto> GetUserInfoAsync(ClaimsPrincipal user, CancellationToken cancellationToken)
    {
        return downstreamClient.GetUserInfoAsync(user, cancellationToken);
    }
}
