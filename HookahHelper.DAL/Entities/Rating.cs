namespace HookahHelper.DAL.Entities;

public class Rating: BaseEntity
{
    public required string TobaccoRatingId { get; set; }
    public required float Value { get; set; } = 0;
    
    public virtual TobaccoRating TobaccoRating { get; set; }
    
    // public float Value { get; set; }
    // public int VotedValue { get; set; }
    // public int VotedCount { get; set; }
}