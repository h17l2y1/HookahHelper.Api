using System;
using HookahHelper.BLL.Services;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.Providers;
using HookahHelper.BLL.Providers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.BLL.Config;

public static class BusinessLogicDependencies
{
    public static void Add(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ILineService, LineService>();
        services.AddScoped<ITobaccoService, TobaccoService>();
        services.AddScoped<IHeavinessService, HeavinessService>();
        services.Configure<ImgurOptions>(configuration.GetSection(ImgurOptions.SectionName));
        services.AddHttpClient<IImgurService, ImgurService>(client =>
        {
            client.BaseAddress = new Uri("https://api.imgur.com/3/");
        });
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ITobaccoMixService, TobaccoMixService>();
        services.AddScoped<IMixService, MixService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IReviewService, ReviewService>();
    }
}
