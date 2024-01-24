using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Image;

public record UpdateImageRequest
{
    [Required]
    public required string Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    public string? Base64 { get; set; }
    public string? Link { get; set; }
    public string? Type { get; set; }
}