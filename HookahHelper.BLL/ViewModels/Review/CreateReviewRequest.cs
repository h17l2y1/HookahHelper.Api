using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Review;

public class CreateReviewRequest
{
    public int? TobaccoId { get; set; }
    public int? MixId { get; set; }
    public int? UserId { get; set; }
    [DefaultValue(null)]
    public string? Name { get; set; }
    [Required]
    [DefaultValue(false)]
    public required bool IsAnonymous { get; set; }
    [Required]
    public required double Rating { get; set; }
    [DefaultValue(null)]
    public string? Comment { get; set; }
}