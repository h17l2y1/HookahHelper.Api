using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Line;

public record CreateLineRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue(null)]
    public string? Description { get; set; }
    [Required]
    public required string BrandId { get; set; }
}