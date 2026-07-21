using Duende.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RGF.Demo.IDP.Data;
using RGF.Demo.IDP.Models;
using Serilog;
using System.Security.Claims;

namespace RGF.Demo.IDP;

public class SeedDataRGF
{
    public static async Task EnsureSeedDataAsync(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await CreateRoleAsync(roleMgr, "Administrators");
            await CreateRoleAsync(roleMgr, "Users");
            await CreateRoleAsync(roleMgr, "Role1");

            await CreateUserAsync(userMgr, "admin", "admin@rgf.demo", new[] { "Administrators" });
            await CreateUserAsync(userMgr, "user1", "user1@rgf.demo", new[] { "Users", "Role1" });
            await CreateUserAsync(userMgr, "user2", "user2@rgf.demo", new[] { "Users" });
            await CreateUserAsync(userMgr, "user3", "user3@rgf.demo", new[] { "Users" });
        }
    }

    private static async Task<string> CreateRoleAsync(RoleManager<IdentityRole> roleMgr, string roleName)
    {
        var role = roleMgr.FindByNameAsync(roleName).Result;
        if (role == null)
        {
            role = new IdentityRole(roleName)
            {
                Name = roleName
            };
            var result = await roleMgr.CreateAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
        return role.Id;
    }

    private static async Task CreateUserAsync(UserManager<ApplicationUser> userMgr, string username, string email, string[] roles)
    {
        var user = userMgr.FindByNameAsync(username).Result;
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                EmailConfirmed = true,
            };
            var result = await userMgr.CreateAsync(user, "rgfdemo");
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            foreach (var role in roles)
            {
                await userMgr.AddToRoleAsync(user, role);
            }
            result = await userMgr.AddClaimsAsync(user, new Claim[]{
                            new Claim(JwtClaimTypes.Name, $"RGF {username}"),
                        });
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            Log.Debug($"{username} created");
        }
    }
}
