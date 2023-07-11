using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Line;

namespace HookahHelper.BLL.ViewModels.Brands;

public record CreateBrandRequest
{
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public required string CountryId { get; set; }
    public IEnumerable<GetLineResponse>? Lines { get; set; }
}