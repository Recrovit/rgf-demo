using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recrovit.RecroGridFramework.Data;

namespace RGF.Demo.MVC.Data;

public class AspNetIdentityDbContextSQLServer : IdentityDbContext
{
    public AspNetIdentityDbContextSQLServer(DbContextOptions<AspNetIdentityDbContextSQLServer> options) : base(options) { }
}

public class AspNetIdentityDbContextPostgreSQL : IdentityDbContext
{
    public AspNetIdentityDbContextPostgreSQL(DbContextOptions<AspNetIdentityDbContextPostgreSQL> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        RGDataContext.InitDbTypeDependentNames(DBTypeEnum.PostgreSQL, builder);
    }
}

public class AspNetIdentityDbContextOracle : IdentityDbContext
{
    public AspNetIdentityDbContextOracle(DbContextOptions<AspNetIdentityDbContextOracle> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        RGDataContext.InitDbTypeDependentNames(DBTypeEnum.Oracle, builder);
    }
}

//Add-Migration aspnetidentity -Context AspNetIdentityDbContextSQLServer -OutputDir Data\Migrations\SQLServer
//Add-Migration aspnetidentity -Context AspNetIdentityDbContextPostgreSQL -OutputDir Data\Migrations\PostgreSQL
//Add-Migration aspnetidentity -Context AspNetIdentityDbContextOracle -OutputDir Data\Migrations\Oracle

public static class WebApplicationBuilderExtensions
{
    public static void AddAspNetIdentity(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var dbType = RGDataContext.DatabaseTypeFromConnectionName;
        switch (dbType)
        {
            case DBTypeEnum.SQLServer:
                services.AddDbContext<AspNetIdentityDbContextSQLServer>(options =>
                    options.UseSqlServer(RGDataContext.DefaultConnectionString));
                break;

            case DBTypeEnum.PostgreSQL:
                services.AddDbContext<AspNetIdentityDbContextPostgreSQL>(options =>
                    options.UseNpgsql(RGDataContext.DefaultConnectionString));
                break;

            case DBTypeEnum.Oracle:
                services.AddDbContext<AspNetIdentityDbContextOracle>(options =>
                    options.UseOracle(RGDataContext.DefaultConnectionString, o => o.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion21)));
                break;
        }

        IdentityBuilder identityBuilder = services.AddDefaultIdentity<IdentityUser>(options =>
        {
            //options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequiredLength = 6;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;

            // User settings
            options.User.RequireUniqueEmail = true;
        });

        switch (dbType)
        {
            case DBTypeEnum.SQLServer:
                identityBuilder.AddEntityFrameworkStores<AspNetIdentityDbContextSQLServer>();
                break;

            case DBTypeEnum.PostgreSQL:
                identityBuilder.AddEntityFrameworkStores<AspNetIdentityDbContextPostgreSQL>();
                break;

            case DBTypeEnum.Oracle:
                identityBuilder.AddEntityFrameworkStores<AspNetIdentityDbContextOracle>();
                break;
        }
    }

    public static async Task MigrateAspNetIdentityAsync(this WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var dbType = RGDataContext.DatabaseTypeFromConnectionName;
            IdentityDbContext? dbContext = null;
            switch (dbType)
            {
                case DBTypeEnum.SQLServer:
                    dbContext = serviceScope.ServiceProvider.GetService<AspNetIdentityDbContextSQLServer>();
                    break;

                case DBTypeEnum.PostgreSQL:
                    dbContext = serviceScope.ServiceProvider.GetService<AspNetIdentityDbContextPostgreSQL>();
                    break;

                case DBTypeEnum.Oracle:
                    dbContext = serviceScope.ServiceProvider.GetService<AspNetIdentityDbContextOracle>();
                    break;
            }
            if (dbContext != null)
            {
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}
