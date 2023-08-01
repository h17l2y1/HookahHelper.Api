using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tag;

public class UpdateTagRequest
{
    [Required]
    public required string Id { get; set; }
    public string? Name { get; set; }
}