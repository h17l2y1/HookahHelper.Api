using HookahHelper.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.DAL.Config;

public class Initializer
{
    public static void SeedData(IServiceCollection services)
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        // SeedCountries(serviceProvider).Wait();
        // SeedHeaviness(serviceProvider).Wait();
    }
    
    private static async Task SeedCountries(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetService<ApplicationContext>();

        if (!context.Countries.Any())
        {
            List<Country> countryList = new List<Country>()
            {
                new Country() { Name = "Ukraine", Id = "1003f7b9-a46a-4ae0-8d8b-0eba84e7f3cd" },
                new Country() { Name = "Brazil", Id = "fb341cb5-9638-415d-809d-83bf09a52c18" },
                new Country() { Name = "Turkiye", Id = "83f34040-4a5b-464c-9774-c1b84e0b2267" },
                new Country() { Name = "USA", Id = "ecdc2df0-7f80-4a00-bdf3-b488f5923131" },
                new Country() { Name = "Germany", Id = "3518eec4-b852-4e5e-a406-3a95a5e641dc" },
                new Country() { Name = "Italy", Id = "28fd943f-fb34-4a6e-a340-6053ba06a059" },
            };

            await context.AddRangeAsync(countryList);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedHeaviness(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetService<ApplicationContext>();

        if (!context.Heaviness.Any())
        {
            List<Heaviness> heavinessesList = new List<Heaviness>()
            {
                new Heaviness() { Name = "Easy", Value = 1, Id = "56748835-5220-469b-8e4b-99061cf1f27a" },
                new Heaviness() { Name = "Medium", Value = 2, Id = "4bd0d95c-3b73-40cc-a362-ecf5c9b79e5f" },
                new Heaviness() { Name = "Strong", Value = 3, Id = "c3dae55d-5676-4428-a6fa-07c8b2a20032" },
            };

            await context.AddRangeAsync(heavinessesList);
            await context.SaveChangesAsync();
        }
    }
}