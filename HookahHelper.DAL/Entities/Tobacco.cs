namespace HookahHelper.DAL.Entities;

public class Tobacco: BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? LineId { get; set; }
    public required string ImageId { get; set; }
    public required string BrandId { get; set; }

    public virtual Line Line { get; set; }
    public virtual Image Image { get; set; }
    public virtual Brand Brand { get; set; }
}