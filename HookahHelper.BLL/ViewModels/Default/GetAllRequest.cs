namespace HookahHelper.BLL.ViewModels.Default;

public record GetAllRequest
{
    public int Page { get; set; } = 0;
    public int Take { get; set; } = 100;
    public string SortBy { get; set; } = "asc";
    public string Column { get; set; } = "name";
    public string? Name { get; set; }
    public string? TagId { get; set; }
    public string? BrandId { get; set; }
    public string? CountryId { get; set; }
    public string? LineId { get; set; }
    public string? HeavinessId { get; set; }
}