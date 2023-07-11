using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Line;

namespace HookahHelper.BLL.ViewModels.Brands;

public record UpdateBrandRequest
{
    [Required]
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public required string CountryId { get; set; }
    public IEnumerable<UpdateLineResponse>? Lines { get; set; }
}