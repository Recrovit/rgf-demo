using RGFDemo.BlazorApp.Client.Models;

namespace RGFDemo.BlazorApp.Client.Services;

public interface IUserInfoApiClient
{
    Task<UserInfoDto> GetAsync(CancellationToken cancellationToken = default);
}
