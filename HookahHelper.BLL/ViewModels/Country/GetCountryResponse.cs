namespace HookahHelper.BLL.ViewModels.Country;

public record GetCountryResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
}