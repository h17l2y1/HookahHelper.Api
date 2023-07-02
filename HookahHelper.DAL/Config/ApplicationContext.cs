using HookahHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Config;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        // TODO: check all methods
        // Database.EnsureCreated();
    }
		
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Line> Lines { get; set; }
    public DbSet<Tobacco> Tobaccos { get; set; }
}