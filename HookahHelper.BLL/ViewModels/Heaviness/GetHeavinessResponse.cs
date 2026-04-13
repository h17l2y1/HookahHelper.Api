namespace HookahHelper.BLL.ViewModels.Heaviness;

public record GetHeavinessResponse
{
    public required int id { get; set; }
    public required string Name { get; set; }
}