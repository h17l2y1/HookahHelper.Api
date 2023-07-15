using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Line;

namespace HookahHelper.BLL.ViewModels.Brands;

public record UpdateBrandRequest
{
    [Required]
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [Required]
    public required string CountryId { get; set; }
    public IEnumerable<UpdateLineRequest>? Lines { get; set; }
}