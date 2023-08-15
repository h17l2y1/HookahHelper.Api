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
            c.AddProfile(new OtherProfile());
            c.AddProfile(new BrandProfile());
            c.AddProfile(new LineProfile());
            c.AddProfile(new ImageProfile());
            c.AddProfile(new CountryProfile());
            c.AddProfile(new TobaccoProfile());
            c.AddProfile(new HeavinessProfile());
            c.AddProfile(new TagProfile());
            c.AddProfile(new TobaccoTagProfile());
        });

        IMapper mapper = config.CreateMapper();

        services.AddSingleton(mapper);
    }
}