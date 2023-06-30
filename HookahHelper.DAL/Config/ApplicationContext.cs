using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Config;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
		
    // public DbSet<Ingredient> Ingredients { get; set; }
}