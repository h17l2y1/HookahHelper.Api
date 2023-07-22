using HookahHelper.BLL.ViewModels.Image;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public record GetTobaccoResponse
{
    public required string Name { get; set; }
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
    public GetImageResponse Image { get; set; }
}