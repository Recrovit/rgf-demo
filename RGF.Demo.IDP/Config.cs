using Duende.IdentityServer.Models;

namespace RGF.Demo.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("role", "User roles", new [] { "role" })
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("api://RgfDemo.Api/API.Access", "RGFDemo API"),
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("api://RgfDemo.Api", "RGFDemoAPI", new [] { "name", "email", "role" })
            {
                Scopes = new[] { "api://RgfDemo.Api/API.Access" }
            }
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "RGF.DemoApp",
                ClientName = "RGF.DemoApp",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = { new Secret("rgf-demoapp-duende-secret".Sha256()) },
                RequireClientSecret = true,
                RequirePkce = true,
                AllowOfflineAccess = true,
                RedirectUris = { "https://localhost:44316/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:44316/signout-callback-oidc" },
                AllowedCorsOrigins = { "https://jwt.io", "https://localhost:11913", "https://localhost:11920", "https://localhost:44316" },
                AllowedScopes = { "openid", "profile", "role", "api://RgfDemo.Api/API.Access", "offline_access" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "RgfDemo.Client",
                ClientName = "RGF Demo",
                AllowedGrantTypes = GrantTypes.Code,
                //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris = { "https://localhost:11920/authentication/login-callback", "https://localhost:44315/authentication/login-callback" },
                //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:11920/authentication/logout-callback" },
                AllowedCorsOrigins = { "https://jwt.io", "https://localhost:11913", "https://localhost:11920", "https://localhost:44315" },
                AllowedScopes = { "openid", "profile", "role", "api://RgfDemo.Api/API.Access" },
                //RequireConsent = true
            }
        };
}
