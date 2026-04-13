using HookahHelper.BLL.ViewModels.Country;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.Line;

namespace HookahHelper.BLL.ViewModels.Brands;

public record GetBrandResponse
{
    public required int id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required GetCountryResponse Country { get; set; }
    public required GetImageResponse Image { get; set; }
    public IEnumerable<GetLineResponse>? Lines { get; set; }
}