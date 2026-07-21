using Microsoft.AspNetCore.Authentication.JwtBearer;
using Recrovit.RecroGridFramework.Extensions;
using RGF.Demo.Northwind.Area.RGF.DbModel;
using System.IdentityModel.Tokens.Jwt;

namespace RGF.Demo.API;

public static class Config
{
    public static WebApplicationBuilder AddRgfDemo(this WebApplicationBuilder builder, bool enableRgfClient)
    {
        if (enableRgfClient)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("RGF.Client", b =>
                {
                    var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();
                    if (allowedOrigins != null)
                    {
                        b.WithOrigins(allowedOrigins)
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    }
                });
            });

            var provider = builder.Configuration.GetValue("JwtBearerOptions:Provider", "Duende");
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options => builder.Configuration.Bind($"JwtBearerOptions:{provider}", options));
        }

        builder.Services.AddControllersWithViews();

        builder.AddRGF();
        builder.AddBaseDbContext();

        return builder;
    }

    public static async Task UseRgfDemoAsync(this IApplicationBuilder app, bool enableRgfClient)
    {
        app.UseStaticFiles();
        app.UseRouting();

        if (enableRgfClient)
        {
            app.UseCors("RGF.Client");
            app.UseAuthentication();
        }
        app.UseAuthorization();

        await app.MigrateBaseDbContextAsync();
        app.UseRGF<BaseDbContext, BaseDbContextPool, BaseDbContextPool>();
    }
}
