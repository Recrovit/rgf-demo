using System.Text.Json;
using RGF.DemoApp.Features.UserInfo;
using Xunit;

namespace RGF.DemoApp.Tests.UserInfo;

public sealed class UserInfoResponseParserTests
{
    [Fact]
    public void Parse_AllowsProfilesWithoutRoleClaim()
    {
        using var document = JsonDocument.Parse("""
        {
          "sub": "user-123",
          "name": "Ada Lovelace",
          "email": "ada@example.com",
          "tid": "tenant-1"
        }
        """);

        var result = UserInfoResponseParser.Parse(document.RootElement);

        Assert.Equal("user-123", result.Subject);
        Assert.Equal("Ada Lovelace", result.Name);
        Assert.Equal("ada@example.com", result.Email);
        Assert.Empty(result.Roles);
        Assert.Equal(["tenant-1"], result.AdditionalClaims["tid"]);
    }

    [Fact]
    public void Parse_MapsRolesAndEmailFallbackClaims()
    {
        using var document = JsonDocument.Parse("""
        {
          "sub": "user-456",
          "name": "Grace Hopper",
          "emails": [ "grace@example.com" ],
          "roles": [ "Admin", "Reader" ],
          "preferred_username": "grace@example.com"
        }
        """);

        var result = UserInfoResponseParser.Parse(document.RootElement);

        Assert.Equal("user-456", result.Subject);
        Assert.Equal("Grace Hopper", result.Name);
        Assert.Equal("grace@example.com", result.Email);
        Assert.Equal(["Admin", "Reader"], result.Roles);
        Assert.Equal(["grace@example.com"], result.AdditionalClaims["emails"]);
        Assert.Equal(["grace@example.com"], result.AdditionalClaims["preferred_username"]);
    }
}
