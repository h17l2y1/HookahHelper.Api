using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Image;

public record UpdateImageRequest
{
    [Required]
    public required string Id { get; set; }
    [Required]
    public required string Base64 { get; set; }
}