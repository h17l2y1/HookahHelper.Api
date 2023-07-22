using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Image;

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
    [Required]
    public required UpdateImageRequest Image { get; set; }
    public IEnumerable<LinesInnerUpdate>? Lines { get; set; }
}

public record LinesInnerUpdate
{
    [Required]
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
}