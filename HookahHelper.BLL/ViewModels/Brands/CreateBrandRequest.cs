using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Image;

namespace HookahHelper.BLL.ViewModels.Brands;

public record CreateBrandRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [Required]
    public required string CountryId { get; set; }
    [Required]
    public required CreateImageRequest Image { get; set; }
    public IEnumerable<LinesInner>? Lines { get; set; }
}

public record LinesInner
{
    [DefaultValue(null)]
    public string? Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
}

// public record ImageInner
// {
//     [Required]
//     public required string Base64 { get; set; }
// }
