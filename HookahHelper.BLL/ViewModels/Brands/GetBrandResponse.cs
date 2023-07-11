using HookahHelper.BLL.ViewModels.Line;

namespace HookahHelper.BLL.ViewModels.Brands;

public record GetBrandResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string CountryId { get; set; }
    public IEnumerable<GetLineResponse>? Lines { get; set; }
}