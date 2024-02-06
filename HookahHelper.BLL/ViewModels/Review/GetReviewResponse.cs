namespace HookahHelper.BLL.ViewModels.Review;

public record GetReviewResponse
{
    public required string TobaccoId { get; set; }
    public string? UserId { get; set; }
    public required bool IsAnonymous { get; set; }
    public required double Rating { get; set; }
    public string? Comment { get; set; }
    public required string Name { get; set; }
    public DateTime CreationDate { get; set; }
}
