namespace HookahHelper.DAL.Entities;

public class Mix : BaseEntity
{
    public required string Name { get; set; }
    public string? RatingId { get; set; }
    public required IEnumerable<TobaccoMix> TobaccoMixes { get; set; }

    public virtual Rating Rating { get; set; }
}