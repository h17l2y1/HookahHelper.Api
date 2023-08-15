namespace HookahHelper.BLL.ViewModels.TobaccoTag;

public record TobaccoTagRequest
{
    public required string TagId { get; set; }
    public required string TobaccoId { get; set; }
}