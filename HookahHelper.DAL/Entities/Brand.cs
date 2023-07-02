namespace HookahHelper.DAL.Entities;

public class Brand: BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Country Country { get; set; }
    public List<Line> Line { get; set; }
}