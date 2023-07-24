using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public class UpdateTobaccoRequest
{
    public required string Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    public int Sweetness { get; set; }
    public int Acidity { get; set; }
    public int Spice { get; set; }
    public int Freshness { get; set; }
    public int Rating { get; set; }
    public int Taste { get; set; }
    public int Fortress { get; set; }
    public int Smokiness { get; set; }
    public string? LineId { get; set; }
    public string? ImageId { get; set; }
}