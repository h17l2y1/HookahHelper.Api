using HookahHelper.BLL.ViewModels.TobaccoMix;

namespace HookahHelper.BLL.ViewModels.Mix;

public class MixResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<TobaccoMixResponse> TobaccoMixes { get; set; }
}