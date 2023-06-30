using HookahHelper.DAL.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.BLL.Config;

public static class ConfigureBusinessLogic
{
    public static void InjectBusinessLogicDependency(this IServiceCollection services, ConfigurationManager configuration)
    {
        AutoMapper.Add(services);
        BusinessLogicDependencies.Add(services);
        services.InjectDataAccessDependency(configuration);
    }
}