namespace HookahHelper.DAL.Entities;

public class TobaccoMix : BaseEntity
{
    public required string TobaccoId { get; set; }
    public required int Percent { get; set; }
}