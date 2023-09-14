namespace HookahHelper.BLL.ViewModels.Comments;

public record GetCommentResponse
{
    public required string Id { get; set; }
    public required string TobaccoId { get; set; }
    public required string UserId { get; set; }
    public required string Text { get; set; }
    public required int Rating { get; set; }
}