using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Enums;

namespace HookahHelper.BLL.ViewModels.Line;

public record GetLineResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public HeavinessType Heaviness { get; set; }
    public IEnumerable<GetTobaccoResponse>? Tobaccos { get; set; }
    public required string BrandId { get; set; }
}