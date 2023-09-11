using HookahHelper.BLL.ViewModels.Comments;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.Tag;
using HookahHelper.BLL.ViewModels.TobaccoTag;

namespace HookahHelper.BLL.ViewModels.Tobacco;

public record GetTobaccoResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string LineId { get; set; }
    public required string BrandId { get; set; }
    public required string HeavinessId { get; set; }
    public required float Rating { get; set; }
    public GetImageResponse Image { get; set; }
    public GetBrandInner Brand { get; set; }
    public IEnumerable<GetTagResponse>? Tags { get; set; }
    public IEnumerable<TobaccoTagRequest>? TobaccoTags { get; set; }
    public IEnumerable<GetCommentResponse>? Comments { get; set; }
}

public record GetBrandInner
{
    public required string Id { get; set; }
    public required string Name { get; set; }
}