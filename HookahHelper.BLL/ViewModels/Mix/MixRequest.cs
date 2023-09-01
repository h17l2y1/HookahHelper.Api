using HookahHelper.BLL.ViewModels.TobaccoMix;

namespace HookahHelper.BLL.ViewModels.Mix;

public class MixRequest
{
    public required string Name { get; set; }
    public required IEnumerable<CreateTobaccoMixRequest> TobaccoMixes { get; set; }
}