using HookahHelper.BLL.ViewModels.Review;
using HookahHelper.BLL.ViewModels.TobaccoMix;

namespace HookahHelper.BLL.ViewModels.Mix;

public record MixResponse
{
    public required int id { get; set; }
    public required string Name { get; set; }
    public required double Rating { get; set; }
    
    public required int RatingCount { get; set; }
    public required int CommentsCount { get; set; }
    
    public IEnumerable<GetReviewResponse>? Reviews { get; set; }
    public required IEnumerable<TobaccoMixResponse> TobaccoMixes { get; set; }
}