using System.Text.Json;
using HookahHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.DAL.Config;

public class Initializer
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        await context.Database.MigrateAsync();
        await SeedCountries(context);
        await SeedHeaviness(context);
        await SeedTags(context);
    }
    
    private static async Task SeedCountries(ApplicationContext context)
    {
        if (!context.Countries.Any())
        {
            List<Country> countryList = new List<Country>()
            {
                new Country() { Name = "Ukraine" },
                new Country() { Name = "Brazil" },
                new Country() { Name = "Turkiye" },
                new Country() { Name = "USA" },
                new Country() { Name = "Germany" },
                new Country() { Name = "Italy" },
            };

            await context.AddRangeAsync(countryList);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedHeaviness(ApplicationContext context)
    {
        if (!context.Heaviness.Any())
        {
            List<Heaviness> list = new List<Heaviness>()
            {
                new Heaviness() { Name = "Easy", Value = 1 },
                new Heaviness() { Name = "Medium", Value = 2 },
                new Heaviness() { Name = "Strong", Value = 3 },
            };

            await context.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedTags(ApplicationContext context)
    {
        if (!context.Tags.Any())
        {
            string json = "[\n  { \"Name\": \"Apple\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Banana\", \"Color\": \"#FBC02D\" },\n  { \"Name\": \"Orange\", \"Color\": \"#FB8C00\" },\n  { \"Name\": \"Lemon\", \"Color\": \"#FFEB3B\" },\n  { \"Name\": \"Lime\", \"Color\": \"#66BB6A\" },\n  { \"Name\": \"Pear\", \"Color\": \"#8BC34A\" },\n  { \"Name\": \"Peach\", \"Color\": \"#FFB74D\" },\n  { \"Name\": \"Nectarine\", \"Color\": \"#FF8A65\" },\n  { \"Name\": \"Plum\", \"Color\": \"#8E24AA\" },\n  { \"Name\": \"Apricot\", \"Color\": \"#F9A825\" },\n  { \"Name\": \"Cherry\", \"Color\": \"#C2185B\" },\n  { \"Name\": \"Sour Cherry\", \"Color\": \"#AD1457\" },\n  { \"Name\": \"Grape\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Green Grape\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Red Grape\", \"Color\": \"#7B1FA2\" },\n  { \"Name\": \"Black Grape\", \"Color\": \"#4A148C\" },\n  { \"Name\": \"Watermelon\", \"Color\": \"#43A047\" },\n  { \"Name\": \"Cantaloupe\", \"Color\": \"#FFA726\" },\n  { \"Name\": \"Honeydew\", \"Color\": \"#AED581\" },\n  { \"Name\": \"Pineapple\", \"Color\": \"#FDD835\" },\n  { \"Name\": \"Mango\", \"Color\": \"#FFA000\" },\n  { \"Name\": \"Papaya\", \"Color\": \"#FF7043\" },\n  { \"Name\": \"Guava\", \"Color\": \"#81C784\" },\n  { \"Name\": \"Passion Fruit\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Dragon Fruit\", \"Color\": \"#EC407A\" },\n  { \"Name\": \"Kiwi\", \"Color\": \"#7CB342\" },\n  { \"Name\": \"Golden Kiwi\", \"Color\": \"#FBC02D\" },\n  { \"Name\": \"Strawberry\", \"Color\": \"#E53935\" },\n  { \"Name\": \"Blueberry\", \"Color\": \"#3949AB\" },\n  { \"Name\": \"Blackberry\", \"Color\": \"#311B92\" },\n  { \"Name\": \"Raspberry\", \"Color\": \"#D81B60\" },\n  { \"Name\": \"Cranberry\", \"Color\": \"#B71C1C\" },\n  { \"Name\": \"Lingonberry\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Gooseberry\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Currant\", \"Color\": \"#B71C1C\" },\n  { \"Name\": \"Blackcurrant\", \"Color\": \"#4527A0\" },\n  { \"Name\": \"Redcurrant\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"White Currant\", \"Color\": \"#F5F5DC\" },\n  { \"Name\": \"Mulberry\", \"Color\": \"#4E342E\" },\n  { \"Name\": \"Boysenberry\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Coconut\", \"Color\": \"#A1887F\" },\n  { \"Name\": \"Pomegranate\", \"Color\": \"#B71C1C\" },\n  { \"Name\": \"Fig\", \"Color\": \"#6D4C41\" },\n  { \"Name\": \"Date\", \"Color\": \"#8D6E63\" },\n  { \"Name\": \"Persimmon\", \"Color\": \"#F57C00\" },\n  { \"Name\": \"Pomelo\", \"Color\": \"#C0CA33\" },\n  { \"Name\": \"Grapefruit\", \"Color\": \"#FF5252\" },\n  { \"Name\": \"Tangerine\", \"Color\": \"#FF9800\" },\n  { \"Name\": \"Mandarin\", \"Color\": \"#FFA000\" },\n  { \"Name\": \"Clementine\", \"Color\": \"#FFB300\" },\n  { \"Name\": \"Satsuma\", \"Color\": \"#FFA726\" },\n  { \"Name\": \"Yuzu\", \"Color\": \"#FFD54F\" },\n  { \"Name\": \"Kumquat\", \"Color\": \"#FFB74D\" },\n  { \"Name\": \"Citron\", \"Color\": \"#FFF176\" },\n  { \"Name\": \"Ugli Fruit\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Blood Orange\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Loquat\", \"Color\": \"#FFCC80\" },\n  { \"Name\": \"Lychee\", \"Color\": \"#F8BBD0\" },\n  { \"Name\": \"Longan\", \"Color\": \"#D7CCC8\" },\n  { \"Name\": \"Rambutan\", \"Color\": \"#E53935\" },\n  { \"Name\": \"Mangosteen\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Durian\", \"Color\": \"#9E9D24\" },\n  { \"Name\": \"Jackfruit\", \"Color\": \"#C0CA33\" },\n  { \"Name\": \"Breadfruit\", \"Color\": \"#8BC34A\" },\n  { \"Name\": \"Starfruit\", \"Color\": \"#FFEB3B\" },\n  { \"Name\": \"Tamarind\", \"Color\": \"#795548\" },\n  { \"Name\": \"Jujube\", \"Color\": \"#A1887F\" },\n  { \"Name\": \"Quince\", \"Color\": \"#D4E157\" },\n  { \"Name\": \"Medlar\", \"Color\": \"#8D6E63\" },\n  { \"Name\": \"Crab Apple\", \"Color\": \"#E53935\" },\n  { \"Name\": \"Plantain\", \"Color\": \"#FDD835\" },\n  { \"Name\": \"Acerola\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Ackee\", \"Color\": \"#FF7043\" },\n  { \"Name\": \"African Cucumber\", \"Color\": \"#FFA726\" },\n  { \"Name\": \"Ambarella\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Atemoya\", \"Color\": \"#AED581\" },\n  { \"Name\": \"Avocado\", \"Color\": \"#558B2F\" },\n  { \"Name\": \"Bael\", \"Color\": \"#A1887F\" },\n  { \"Name\": \"Barbadine\", \"Color\": \"#7B1FA2\" },\n  { \"Name\": \"Bilberry\", \"Color\": \"#283593\" },\n  { \"Name\": \"Black Sapote\", \"Color\": \"#4E342E\" },\n  { \"Name\": \"Canistel\", \"Color\": \"#FBC02D\" },\n  { \"Name\": \"Cape Gooseberry\", \"Color\": \"#FFB300\" },\n  { \"Name\": \"Carambola\", \"Color\": \"#FFEB3B\" },\n  { \"Name\": \"Cashew Apple\", \"Color\": \"#FF7043\" },\n  { \"Name\": \"Cherimoya\", \"Color\": \"#C5E1A5\" },\n  { \"Name\": \"Cloudberry\", \"Color\": \"#FFB74D\" },\n  { \"Name\": \"Damson\", \"Color\": \"#5E35B1\" },\n  { \"Name\": \"Desert Lime\", \"Color\": \"#8BC34A\" },\n  { \"Name\": \"Feijoa\", \"Color\": \"#66BB6A\" },\n  { \"Name\": \"Finger Lime\", \"Color\": \"#43A047\" },\n  { \"Name\": \"Gac\", \"Color\": \"#EF6C00\" },\n  { \"Name\": \"Genip\", \"Color\": \"#7CB342\" },\n  { \"Name\": \"Hala Fruit\", \"Color\": \"#FF7043\" },\n  { \"Name\": \"Hawthorn Berry\", \"Color\": \"#B71C1C\" },\n  { \"Name\": \"Hog Plum\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Huckleberry\", \"Color\": \"#3949AB\" },\n  { \"Name\": \"Illawarra Plum\", \"Color\": \"#4527A0\" },\n  { \"Name\": \"Indian Fig\", \"Color\": \"#EC407A\" },\n  { \"Name\": \"Indian Gooseberry\", \"Color\": \"#AED581\" },\n  { \"Name\": \"Jabuticaba\", \"Color\": \"#311B92\" },\n  { \"Name\": \"Java Apple\", \"Color\": \"#F06292\" },\n  { \"Name\": \"Kaffir Lime\", \"Color\": \"#4CAF50\" },\n  { \"Name\": \"Kei Apple\", \"Color\": \"#FBC02D\" },\n  { \"Name\": \"Langsat\", \"Color\": \"#FFF9C4\" },\n  { \"Name\": \"Lanzones\", \"Color\": \"#FFF176\" },\n  { \"Name\": \"Lucuma\", \"Color\": \"#D4E157\" },\n  { \"Name\": \"Mamey Sapote\", \"Color\": \"#E64A19\" },\n  { \"Name\": \"Mammee Apple\", \"Color\": \"#FF8F00\" },\n  { \"Name\": \"Marionberry\", \"Color\": \"#4A148C\" },\n  { \"Name\": \"Miracle Fruit\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Monstera Deliciosa\", \"Color\": \"#C0CA33\" },\n  { \"Name\": \"Mountain Pepper Berry\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Naranjilla\", \"Color\": \"#FF9800\" },\n  { \"Name\": \"Olive\", \"Color\": \"#556B2F\" },\n  { \"Name\": \"Orange Berry\", \"Color\": \"#FB8C00\" },\n  { \"Name\": \"Pequi\", \"Color\": \"#F9A825\" },\n  { \"Name\": \"Physalis\", \"Color\": \"#FFB300\" },\n  { \"Name\": \"Pitanga\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Pitaya\", \"Color\": \"#EC407A\" },\n  { \"Name\": \"Prickly Pear\", \"Color\": \"#8E24AA\" },\n  { \"Name\": \"Pulasan\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Salak\", \"Color\": \"#6D4C41\" },\n  { \"Name\": \"Santol\", \"Color\": \"#D7CCC8\" },\n  { \"Name\": \"Sapodilla\", \"Color\": \"#8D6E63\" },\n  { \"Name\": \"Soursop\", \"Color\": \"#C5E1A5\" },\n  { \"Name\": \"Surinam Cherry\", \"Color\": \"#D84315\" },\n  { \"Name\": \"Tayberry\", \"Color\": \"#AD1457\" },\n  { \"Name\": \"White Sapote\", \"Color\": \"#FFF8E1\" },\n  { \"Name\": \"Yangmei\", \"Color\": \"#880E4F\" },\n  { \"Name\": \"Youngberry\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Serviceberry\", \"Color\": \"#5C6BC0\" },\n  { \"Name\": \"Rowan Berry\", \"Color\": \"#D84315\" },\n  { \"Name\": \"Sea Buckthorn\", \"Color\": \"#FF8F00\" },\n  { \"Name\": \"Elderberry\", \"Color\": \"#4527A0\" },\n  { \"Name\": \"Chokeberry\", \"Color\": \"#4E342E\" },\n  { \"Name\": \"Salmonberry\", \"Color\": \"#FF7043\" },\n  { \"Name\": \"Wineberry\", \"Color\": \"#C2185B\" },\n  { \"Name\": \"Buffaloberry\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Juneberry\", \"Color\": \"#5C6BC0\" },\n  { \"Name\": \"Rose Hip\", \"Color\": \"#E64A19\" },\n  { \"Name\": \"Barberry\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Hackberry\", \"Color\": \"#8D6E63\" },\n  { \"Name\": \"Breadnut\", \"Color\": \"#9E9D24\" },\n  { \"Name\": \"Buddha's Hand\", \"Color\": \"#FFEE58\" },\n  { \"Name\": \"Calamansi\", \"Color\": \"#8BC34A\" },\n  { \"Name\": \"Cupuacu\", \"Color\": \"#A1887F\" },\n  { \"Name\": \"Emu Apple\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Governor's Plum\", \"Color\": \"#5E35B1\" },\n  { \"Name\": \"Grumichama\", \"Color\": \"#311B92\" },\n  { \"Name\": \"Imbe\", \"Color\": \"#FFD54F\" },\n  { \"Name\": \"Jocote\", \"Color\": \"#E53935\" },\n  { \"Name\": \"Kabosu\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Korlan\", \"Color\": \"#F06292\" },\n  { \"Name\": \"Lemon Aspen\", \"Color\": \"#FFF59D\" },\n  { \"Name\": \"Lilly Pilly\", \"Color\": \"#C2185B\" },\n  { \"Name\": \"Mamoncillo\", \"Color\": \"#9CCC65\" },\n  { \"Name\": \"Midyim Berry\", \"Color\": \"#CE93D8\" },\n  { \"Name\": \"Natal Plum\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Noni\", \"Color\": \"#C5E1A5\" },\n  { \"Name\": \"Peach Palm Fruit\", \"Color\": \"#F57C00\" },\n  { \"Name\": \"Pawpaw\", \"Color\": \"#AED581\" },\n  { \"Name\": \"Pepino\", \"Color\": \"#FFF176\" },\n  { \"Name\": \"Quandong\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Safou\", \"Color\": \"#512DA8\" },\n  { \"Name\": \"Soncoya\", \"Color\": \"#8BC34A\" },\n  { \"Name\": \"Tangelo\", \"Color\": \"#FF9800\" },\n  { \"Name\": \"Velvet Apple\", \"Color\": \"#8D6E63\" },\n  { \"Name\": \"Wampee\", \"Color\": \"#FDD835\" },\n  { \"Name\": \"White Mulberry\", \"Color\": \"#F5F5F5\" },\n  { \"Name\": \"Wood Apple\", \"Color\": \"#8D6E63\" },\n  { \"Name\": \"Yellow Passion Fruit\", \"Color\": \"#FBC02D\" },\n  { \"Name\": \"Araza\", \"Color\": \"#FFEB3B\" },\n  { \"Name\": \"Babaco\", \"Color\": \"#C0CA33\" },\n  { \"Name\": \"Biriba\", \"Color\": \"#D4E157\" },\n  { \"Name\": \"Cempedak\", \"Color\": \"#F9A825\" },\n  { \"Name\": \"Charichuelo\", \"Color\": \"#FFD54F\" },\n  { \"Name\": \"Chayote Fruit\", \"Color\": \"#AED581\" },\n  { \"Name\": \"Ceylon Gooseberry\", \"Color\": \"#D32F2F\" },\n  { \"Name\": \"Cluster Fig\", \"Color\": \"#8E24AA\" },\n  { \"Name\": \"Desert Quandong\", \"Color\": \"#D84315\" },\n  { \"Name\": \"Governor's Fruit\", \"Color\": \"#6A1B9A\" },\n  { \"Name\": \"Malay Apple\", \"Color\": \"#E53935\" },\n  { \"Name\": \"Mountain Soursop\", \"Color\": \"#A5D6A7\" },\n  { \"Name\": \"Myrciaria Dubia\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Oroblanco\", \"Color\": \"#CDDC39\" },\n  { \"Name\": \"Pichuberry\", \"Color\": \"#FFB300\" },\n  { \"Name\": \"Red Banana\", \"Color\": \"#C62828\" },\n  { \"Name\": \"Red Mombin\", \"Color\": \"#E64A19\" },\n  { \"Name\": \"Rollinia\", \"Color\": \"#FFEE58\" },\n  { \"Name\": \"Star Apple\", \"Color\": \"#7E57C2\" },\n  { \"Name\": \"Sugar Apple\", \"Color\": \"#C5E1A5\" },\n  { \"Name\": \"Tamarillo\", \"Color\": \"#C62828\" },\n  { \"Name\": \"White Currant Berry\", \"Color\": \"#FFFDE7\" },\n  { \"Name\": \"Wild Orange\", \"Color\": \"#FB8C00\" },\n  { \"Name\": \"Yellow Mombin\", \"Color\": \"#FBC02D\" },\n  { \"Name\": \"Ziziphus Fruit\", \"Color\": \"#8D6E63\" }\n]";
            
            List<Tag> tags = JsonSerializer.Deserialize<List<Tag>>(json);
            foreach (var tag in tags)
            {
                tag.IsGlobal = true;
            }
            

            await context.AddRangeAsync(tags);
            await context.SaveChangesAsync();
        }
    }
}
