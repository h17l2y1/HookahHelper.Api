namespace HookahHelper.BLL.ViewModels.Review;

public class GetReviewResponse
{
    public required string TobaccoId { get; set; }
    public string? UserId { get; set; }
    public string? AnonymousName { get; set; }
    public required bool IsAnonymous { get; set; }
    public required float Rating { get; set; }
    public string? Comment { get; set; }
    public GetReviewUser User { get; set; }
    public DateTime CreationDate { get; set; }
}

public class GetReviewUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}