using Microsoft.Extensions.Configuration;
using Recrovit.AspNetCore.Authentication.OpenIdConnect.Configuration;
using Xunit;

namespace RGF.DemoApp.Tests.UserInfo;

public sealed class UserInfoDownstreamConfigurationTests
{
    [Fact]
    public void UserInfoApi_ResolvesDirectlyFromDownstreamApis()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Recrovit:OpenIdConnect:Provider"] = "EntraId",
                ["Recrovit:OpenIdConnect:Providers:EntraId:Authority"] = "https://login.microsoftonline.com/test-tenant/v2.0",
                ["Recrovit:OpenIdConnect:Providers:EntraId:ClientId"] = "demo-client",
                ["Recrovit:OpenIdConnect:Providers:EntraId:ClientSecret"] = "secret",
                ["Recrovit:OpenIdConnect:Providers:EntraId:UserInfo:BaseUrl"] = "https://should-not-be-used.example.com/",
                ["Recrovit:OpenIdConnect:Providers:EntraId:UserInfo:RelativePath"] = "ignored",
                ["Recrovit:OpenIdConnect:DownstreamApis:UserInfoApi:BaseUrl"] = "https://graph.microsoft.com/",
                ["Recrovit:OpenIdConnect:DownstreamApis:UserInfoApi:RelativePath"] = "oidc/userinfo",
                ["Recrovit:OpenIdConnect:DownstreamApis:UserInfoApi:Scopes:0"] = "openid",
                ["Recrovit:OpenIdConnect:DownstreamApis:UserInfoApi:Scopes:1"] = "profile",
                ["Recrovit:OpenIdConnect:DownstreamApis:UserInfoApi:Scopes:2"] = "email"
            })
            .Build();

        var catalog = DownstreamApiCatalog.Create(configuration.GetSection("Recrovit:OpenIdConnect:DownstreamApis"));
        var userInfoApi = catalog.GetRequired("UserInfoApi");

        Assert.Equal("https://graph.microsoft.com/", userInfoApi.BaseUrl);
        Assert.Equal("oidc/userinfo", userInfoApi.RelativePath);
        Assert.Equal(["openid", "profile", "email"], userInfoApi.Scopes);
    }
}
