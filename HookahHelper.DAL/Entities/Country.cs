namespace HookahHelper.DAL.Entities;

public class Country: BaseEntity
{
    public required string Name { get; set; }
    public string? City { get; set; }
}