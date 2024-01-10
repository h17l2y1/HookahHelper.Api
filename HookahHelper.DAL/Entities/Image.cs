namespace HookahHelper.DAL.Entities;

public class Image: BaseEntity
{
    public required string Name { get; set; }
    public required string Link { get; set; }
    public required string Type { get; set; }
}