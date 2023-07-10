namespace HookahHelper.DAL.Entities;

public class Brand: BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string CountryId { get; set; }
    public IEnumerable<Line>? Lines { get; set; }
}