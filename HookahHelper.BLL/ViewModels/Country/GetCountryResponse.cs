namespace HookahHelper.BLL.ViewModels.Country;

public record GetCountryResponse
{
    public required int id { get; set; }
    public required string Name { get; set; }
}