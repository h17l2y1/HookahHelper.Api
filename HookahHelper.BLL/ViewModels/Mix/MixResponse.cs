using HookahHelper.BLL.ViewModels.TobaccoMix;

namespace HookahHelper.BLL.ViewModels.Mix;

public record MixResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required float Rating { get; set; }
    public required IEnumerable<TobaccoMixResponse> TobaccoMixes { get; set; }
}