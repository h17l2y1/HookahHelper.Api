namespace HookahHelper.DAL.Entities.Models;

public record Filter
{
    public string? Name { get; set; }
    public int? TagId { get; set; }
    public int? BrandId { get; set; }
    public int? CountryId { get; set; }
    public int? LineId { get; set; }
    public int? HeavinessId { get; set; }
}