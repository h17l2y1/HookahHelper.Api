namespace HookahHelper.DAL.Entities;

public class Comment: BaseEntity
{
    public required string TobaccoId { get; set; }
    public required string RatingId { get; set; }
    public required string UserId { get; set; }
    public required string Text { get; set; }
    
    public virtual Tobacco Tobacco { get; set; }
    public virtual Rating Rating { get; set; }
    public virtual User User { get; set; }
}