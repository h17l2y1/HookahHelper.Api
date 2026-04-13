namespace HookahHelper.DAL.Entities;

public class Review: BaseEntity
{
    public int? TobaccoId { get; set; }
    public int? MixId { get; set; }
    public int? UserId { get; set; }
    public string? AnonymousName { get; set; }
    public required bool IsAnonymous { get; set; }
    public required double Rating { get; set; }
    public string? Comment { get; set; }
    
    public virtual User User { get; set; }
    public virtual Tobacco Tobacco { get; set; }
    public virtual Mix Mix { get; set; }
}