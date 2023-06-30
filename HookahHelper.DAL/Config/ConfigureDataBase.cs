using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.DAL.Config;

public static class ConfigureDataBase
{
    public static void InjectDataAccessDependency(this IServiceCollection services, ConfigurationManager configuration)
    {
        DatabaseDependencies.Add(services);
        DbConnection.Add(services, configuration);
    }
}