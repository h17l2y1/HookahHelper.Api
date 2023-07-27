namespace HookahHelper.DAL.Entities;

public class Line: BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Tobacco>? Tobaccos { get; set; }
    public required string BrandId { get; set; }

    public virtual Brand Brand { get; set; }
}