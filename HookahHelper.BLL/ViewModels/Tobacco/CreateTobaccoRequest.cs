using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public class CreateTobaccoRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    public string? LineId { get; set; }
    public required string ImageId { get; set; }
    public required string BrandId { get; set; }
}