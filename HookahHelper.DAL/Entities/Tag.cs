namespace HookahHelper.DAL.Entities;

public class Tag : BaseEntity
{
    public required string Name { get; set; }
    public required string Color { get; set; }
    public bool IsGlobal { get; set; }
    public IEnumerable<Tobacco> Tobaccos { get; set; }
    public IEnumerable<TobaccoTag> TobaccoTags { get; set; }
}