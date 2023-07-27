using HookahHelper.BLL.ViewModels.Image;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public record GetTobaccoResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? LineId { get; set; }
    public required string BrandId { get; set; }
    public GetImageResponse Image { get; set; }
}