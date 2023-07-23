namespace HookahHelper.DAL.Entities.Models;

public record Filter
{
    public string? Name { get; set; }
    public string? BrandId { get; set; }
    public string? CountryId { get; set; }
}