namespace HookahHelper.DAL.Entities;

public class Tag : BaseEntity
{
    public required string Name { get; set; }
    public IEnumerable<Tobacco> Tobaccos { get; set; }
}