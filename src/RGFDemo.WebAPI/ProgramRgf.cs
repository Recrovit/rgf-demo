using Microsoft.AspNetCore.Authentication.JwtBearer;
using Recrovit.RecroGridFramework.Extensions;
using RGFDemo.Database.Area.RGF.DbModel;
using System.IdentityModel.Tokens.Jwt;

namespace RGFDemo.WebAPI;

public static class ProgramRgf
{
    public static WebApplicationBuilder AddRgf(this WebApplicationBuilder builder, bool enableRgfClient = true)
    {
        if (builder.Environment.IsDevelopment())
        {
            var provider = builder.Configuration["JwtBearerOptions:Provider"];
            if (provider != "Duende" && !string.IsNullOrWhiteSpace(provider))
            {
                builder.Configuration.AddUserSecrets(provider, reloadOnChange: true);
            }
            Console.WriteLine("Authority: {0}", builder.Configuration[$"JwtBearerOptions:{provider}:Authority"]);
        }

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
                  .AddJwtBearer(options =>
                   {
                       builder.Configuration.Bind($"JwtBearerOptions:{provider}", options);
                       // IDX10500: Signature validation failed. No security keys were provided to validate the signature.
                       options.TokenValidationParameters.SignatureValidator = (token, parameters) => new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(token);
                   });
        }

        builder.Services.AddControllersWithViews();

        builder.AddRGF();
        builder.AddBaseDbContext();

        return builder;
    }

    public static async Task UseRgfAsync(this IApplicationBuilder app, bool enableRgfClient = true)
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
