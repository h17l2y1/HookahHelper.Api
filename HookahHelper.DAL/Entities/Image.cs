namespace HookahHelper.DAL.Entities;

public class Image: BaseEntity
{
    public required string Name { get; set; }
    public required string Base64 { get; set; }
}