using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.DAL.Entities.Enums;

namespace HookahHelper.BLL.ViewModels.Brands;

public record CreateBrandRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue("")]
    public string? Description { get; set; }
    [Required]
    public required string CountryId { get; set; }
    public IEnumerable<LinesInner>? Lines { get; set; }
}

public record LinesInner
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue("")]
    public string? Description { get; set; }
    [DefaultValue(0)]
    public HeavinessType Heaviness { get; set; }
}