namespace HookahHelper.BLL.ViewModels.Line;

public record GetLineResponse
{
    public required int id { get; set; }
    public required string Name { get; set; }
    public required string BrandId { get; set; }
}