namespace HookahHelper.BLL.ViewModels.Country;

public record UpdateCountryRequest
{
    public required string Id { get; set; }
    public required string Name { get; set; }
}