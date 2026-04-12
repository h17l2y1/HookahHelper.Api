using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.DAL.Config;

public static class DbConnection
{
    public static void Add(IServiceCollection services, ConfigurationManager configuration)
    {
        var provider = configuration["Database:Provider"]?.Trim().ToLowerInvariant() ?? "sqlite";
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? configuration["DefaultConnection"];

        services.AddDbContext<ApplicationContext>(options =>
        {
            switch (provider)
            {
                case "sqlite":
                    options
                        .UseSqlite(connectionString)
                        .ConfigureWarnings(warnings =>
                            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
                    break;
                case "postgres":
                case "postgresql":
                case "npgsql":
                    options.UseNpgsql(connectionString);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported database provider '{provider}'.");
            }
        });
    }
}
