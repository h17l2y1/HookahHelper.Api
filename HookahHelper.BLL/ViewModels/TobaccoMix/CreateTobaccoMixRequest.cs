namespace HookahHelper.BLL.ViewModels.TobaccoMix;

public record CreateTobaccoMixRequest
{
    public required string TobaccoId { get; set; }
    public required int Percent { get; set; }
}