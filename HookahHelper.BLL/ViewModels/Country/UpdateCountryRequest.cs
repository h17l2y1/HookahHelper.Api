using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Country;

public record UpdateCountryRequest
{
    [Required]
    public required int id { get; set; }
    [Required]
    public required string Name { get; set; }
}