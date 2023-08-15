using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.TobaccoTag;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public class UpdateTobaccoRequest
{
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    public required string LineId { get; set; }
    public required string HeavinessId { get; set; }
    public required string BrandId { get; set; }
    public required UpdateImageRequest Image { get; set; }
    public IEnumerable<TobaccoTagRequest>? TobaccoTags { get; set; }
}