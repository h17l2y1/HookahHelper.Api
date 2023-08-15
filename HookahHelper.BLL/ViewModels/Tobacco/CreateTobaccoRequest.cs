using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.TobaccoTag;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public class CreateTobaccoRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [Required]
    public required string LineId { get; set; }
    [Required]
    public required string BrandId { get; set; }
    [Required]
    public required string HeavinessId { get; set; }
    public required CreateImageRequest Image { get; set; }
    public IEnumerable<TobaccoTagRequest>? TobaccoTags { get; set; }
}