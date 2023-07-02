using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HookahHelper.DAL.Config;

public static class DbConnection
{
    public static void Add(IServiceCollection services, ConfigurationManager configuration)
    {
        string connectionString = configuration.GetSection("DefaultConnection").Value;
        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
    }
}

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        string connectionString = "";
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationContext(optionsBuilder.Options);
    }
}