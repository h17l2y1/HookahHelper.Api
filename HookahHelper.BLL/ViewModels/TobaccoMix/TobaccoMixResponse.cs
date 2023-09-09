namespace HookahHelper.BLL.ViewModels.TobaccoMix;

public record TobaccoMixResponse
{
    public required string Id { get; set; }
    public required string TobaccoId { get; set; }
    public required int Percent { get; set; }
}