using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Country;

public record CreateCountryRequest
{
    [Required]
    public required string Name { get; set; }
    public string? City { get; set; }
}