namespace HookahHelper.DAL.Entities;

public class TobaccoTag: BaseEntity
{
    public required string TagId { get; set; }
    public required string TobaccoId { get; set; }

    public Tag Type { get; set; }
    public Tobacco Tobacco { get; set; }
}