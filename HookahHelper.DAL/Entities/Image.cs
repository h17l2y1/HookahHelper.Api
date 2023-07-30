namespace HookahHelper.DAL.Entities;

public class Image: BaseEntity
{
    public required string Name { get; set; }
    public string? Link { get; set; }
}