using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Country;

public record UpdateCountryRequest
{
    [Required]
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? City { get; set; }
}