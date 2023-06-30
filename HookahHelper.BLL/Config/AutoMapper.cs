using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.BLL.Config;

public static class AutoMapper
{
    public static void Add(IServiceCollection services)
    {
        var config = new MapperConfiguration(c =>
        {
            // c.AddProfile(new IngredientProfile());
        });

        IMapper mapper = config.CreateMapper();

        services.AddSingleton(mapper);
    }
}