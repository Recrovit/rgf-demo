using System.Reflection;
using Duende.IdentityServer;
using Duende.IdentityServer.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RGF.Demo.IDP.Pages
{
    [AllowAnonymous]
    public class Index : PageModel
    {
        public Index(IdentityServerLicense? license = null) => License = license;

        public string Version => typeof(IdentityServerMiddleware).Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion.Split('+').First()
                ?? "unavailable";
        public IdentityServerLicense? License { get; }
    }
}
