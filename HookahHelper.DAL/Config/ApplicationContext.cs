using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public DbSet<Heaviness> Heaviness { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TobaccoTag> TobaccoTags { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // remove cascade deleting
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
        builder.Entity<Tobacco>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Tobaccos)
            .UsingEntity<TobaccoTag>();

        base.OnModelCreating(builder);
    }
}