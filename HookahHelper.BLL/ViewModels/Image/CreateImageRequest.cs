using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Image;

public record CreateImageRequest
{
    [Required]
    public required string Base64 { get; set; }
    public string? Name { get; set; }
}