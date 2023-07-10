using AutoMapper;
using HookahHelper.BLL.Config.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.BLL.Config;

public static class AutoMapper
{
    public static void Add(IServiceCollection services)
    {
        var config = new MapperConfiguration(c =>
        {
            c.AddProfile(new BrandProfile());
            c.AddProfile(new LineProfile());
        });

        IMapper mapper = config.CreateMapper();

        services.AddSingleton(mapper);
    }
}