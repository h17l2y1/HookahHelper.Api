namespace HookahHelper.BLL.ViewModels.Tag;

public record GetTagResponse
{
    public string? Id { get; set; }
    public required string Name { get; set; }
    public required string Color { get; set; }
    public required bool IsGlobal { get; set; }
}