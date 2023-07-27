using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Brands;

public record CreateBrandRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [Required]
    public required string CountryId { get; set; }
    public ImageInner? Image { get; set; }
    public IEnumerable<LinesInner>? Lines { get; set; }
}

public record LinesInner
{
    [DefaultValue(null)]
    public string? Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
}

public record ImageInner
{
    [Required]
    public required string Base64 { get; set; }
}
