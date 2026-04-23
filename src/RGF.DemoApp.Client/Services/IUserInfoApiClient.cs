using RGF.DemoApp.Client.Models;

namespace RGF.DemoApp.Client.Services;

public interface IUserInfoApiClient
{
    Task<UserInfoDto> GetAsync(CancellationToken cancellationToken = default);
}
