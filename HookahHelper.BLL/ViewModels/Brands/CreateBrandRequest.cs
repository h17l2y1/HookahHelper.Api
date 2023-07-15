using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.DAL.Entities.Enums;

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
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [DefaultValue(0)]
    public HeavinessType Heaviness { get; set; }
}

public record ImageInner
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Base64 { get; set; }
}
