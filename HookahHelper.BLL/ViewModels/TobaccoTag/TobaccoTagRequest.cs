namespace HookahHelper.BLL.ViewModels.TobaccoTag;

public record TobaccoTagRequest
{
    public string? Id { get; set; }
    public required string TagId { get; set; }
    public required string TobaccoId { get; set; }
    public bool? IsNew { get; set; }
    public bool? IsRemoved { get; set; }
}