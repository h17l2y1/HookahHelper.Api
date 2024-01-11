namespace HookahHelper.DAL.Entities;

public class TobaccoRating: BaseEntity
{
    public required string TobaccoId { get; set; }
    public required float Value { get; set; } = 0;
    
    public virtual Tobacco Tobacco { get; set; }
}