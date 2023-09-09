using HookahHelper.BLL.ViewModels.TobaccoMix;

namespace HookahHelper.BLL.ViewModels.Mix;

public record MixRequest
{
    public required string Name { get; set; }
    public required IEnumerable<CreateTobaccoMixRequest> TobaccoMixes { get; set; }
}