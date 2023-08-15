using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.Tag;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public record GetTobaccoResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string LineId { get; set; }
    public required string BrandId { get; set; }
    public required string HeavinessId { get; set; }
    public GetImageResponse Image { get; set; }
    public IEnumerable<GetTagResponse>? Tags { get; set; }
}