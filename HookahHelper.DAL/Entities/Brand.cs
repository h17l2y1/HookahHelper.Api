namespace HookahHelper.DAL.Entities;

public class Brand: BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string CountryId { get; set; }
    public string? ImageId { get; set; }
    public IEnumerable<Line>? Lines { get; set; }

    public virtual Country Country { get; set; }
    public virtual Image Image { get; set; }
}