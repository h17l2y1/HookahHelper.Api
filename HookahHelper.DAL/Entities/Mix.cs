namespace HookahHelper.DAL.Entities;

public class Mix : BaseEntity
{
    public required string Name { get; set; }
    
    public required IEnumerable<TobaccoMix> TobaccoMixes { get; set; }
    
    public required double Rating { get; set; } = 0;
    
    public IEnumerable<Review> Reviews { get; set; }
}