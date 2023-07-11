using HookahHelper.DAL.Entities.Enums;

namespace HookahHelper.BLL.ViewModels.Line;

public class UpdateLineResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public HeavinessType Heaviness { get; set; }
    public required string BrandId { get; set; }
}