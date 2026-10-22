using Microsoft.AspNetCore.Authentication.JwtBearer;
using Recrovit.RecroGridFramework.Extensions;
using Recrovit.RecroGridFramework.AI.Recroby.Extensions;
using RGFDemo.Database.Area.RGF.DbModel;
using System.IdentityModel.Tokens.Jwt;

namespace RGFDemo.WebAPI;

public static class ProgramRgf
{
    public static WebApplicationBuilder AddRgf(this WebApplicationBuilder builder, bool enableRgfClient = true)
    {
        if (builder.Environment.IsDevelopment())
        {
            var liveHost = Environment.GetEnvironmentVariable("RGF_RECROBY_LIVE_HOST_ID") is { Length: > 0 };
            var provider = liveHost ? "Duende" : builder.Configuration["JwtBearerOptions:Provider"];
            if (!string.IsNullOrWhiteSpace(provider))
            {
                builder.Configuration.AddUserSecrets(provider, reloadOnChange: true);
            }
            if (liveHost)
            {
                // A teszt saját folyamatában a titkok betöltése után is rögzített beállítások szükségesek.
                builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["JwtBearerOptions:Provider"] = "Duende",
                    ["Recrovit:AI:Diagnostics:Normalized:Enabled"] = "true",
                    ["Recrovit:AI:Diagnostics:Normalized:IncludeContent"] = "true",
                    ["Recrovit:AI:Diagnostics:StructuredOutput:IncludeContent"] = "true",
                    ["Recrovit:AI:Diagnostics:RawHttp:Enabled"] = "false"
                });
                provider = "Duende";
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

        builder.AddRGFWithRecroby();
        builder.AddBaseDbContext();

        return builder;
    }

    public static async Task UseRgfAsync(this IApplicationBuilder app, bool enableRgfClient = true)
    {
        if (app.ApplicationServices.GetRequiredService<IHostEnvironment>().IsDevelopment()
            && Environment.GetEnvironmentVariable("RGF_RECROBY_LIVE_HOST_ID") is { Length: > 0 } hostId)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/api/rgf/capabilities")
                {
                    context.Response.Headers["X-RGF-Live-Host"] = hostId;
                    context.Response.Headers["X-RGF-Live-Provider"] = app.ApplicationServices
                        .GetRequiredService<IConfiguration>()["JwtBearerOptions:Provider"];
                }
                await next(context);
            });
            // A szülőfolyamat lezárt bemenete is megszünteti a teszt által indított példányt.
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            _ = Task.Run(async () =>
            {
                await Console.In.ReadLineAsync();
                lifetime.StopApplication();
            });
        }
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
