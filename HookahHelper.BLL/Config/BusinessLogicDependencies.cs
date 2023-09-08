using HookahHelper.BLL.Services;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.Providers;
using HookahHelper.BLL.Providers.Interfaces;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.BLL.Config;

public static class BusinessLogicDependencies
{
    public static void Add(IServiceCollection services)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ILineService, LineService>();
        services.AddScoped<ITobaccoService, TobaccoService>();
        services.AddScoped<IHeavinessService, HeavinessService>();
        services.AddScoped<IImgurService, ImgurService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJwtProvider, JwtProvider>();
    }
}