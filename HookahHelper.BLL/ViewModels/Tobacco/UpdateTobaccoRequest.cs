using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.Tag;
using HookahHelper.BLL.ViewModels.TobaccoTag;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public record UpdateTobaccoRequest
{
    [Required]
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [Required]
    public required string LineId { get; set; }
    [Required]
    public required string HeavinessId { get; set; }
    [Required]
    public required string BrandId { get; set; }
    public required float? Rating { get; set; }
    public required UpdateImageRequest Image { get; set; }
    public required IEnumerable<UpdateTobaccoTag> TobaccoTags { get; set; }
    public required IEnumerable<GetTagResponse> Tags { get; set; }
}