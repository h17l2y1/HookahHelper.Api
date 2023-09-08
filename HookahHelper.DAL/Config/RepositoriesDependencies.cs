using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.DAL.Config;

public static class RepositoryDependencies
{
    public static void Add(IServiceCollection services)
    {
        services.AddTransient<IBrandRepository, BrandRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<ILineRepository, LineRepository>();
        services.AddTransient<ITobaccoRepository, TobaccoRepository>();
        services.AddTransient<IImageRepository, ImageRepository>();
        services.AddTransient<IHeavinessRepository, HeavinessRepository>();
        services.AddTransient<ITagRepository, TagRepository>();
        services.AddTransient<ITobaccoTagRepository, TobaccoTagRepository>();
        services.AddTransient<IMixRepository, MixRepository>();
        services.AddTransient<ITobaccoMixRepository, TobaccoMixRepository>();
        
        services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
    }
}