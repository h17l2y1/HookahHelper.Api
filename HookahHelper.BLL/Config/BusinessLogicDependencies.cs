using HookahHelper.BLL.Services;
using HookahHelper.BLL.Services.Interfaces;
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
        services.AddScoped<IDropBoxFilesService, DropBoxFilesService>();
    }
}