namespace HookahHelper.DAL.Entities;

public class Tobacco : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string LineId { get; set; }
    public required string ImageId { get; set; }
    public required string HeavinessId { get; set; }
    public required string BrandId { get; set; }
    public required double Rating { get; set; } = 0;
    public IEnumerable<Tag> Tags { get; set; }
    public IEnumerable<TobaccoTag> TobaccoTags { get; set; }
    public IEnumerable<Review>? Reviews { get; set; }
    
    public virtual Line Line { get; set; }
    public virtual Image Image { get; set; }
    public virtual Heaviness Heaviness { get; set; }
    public virtual Brand Brand { get; set; }
}