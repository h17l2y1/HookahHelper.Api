using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tag;

public record UpdateTagRequest
{
    [Required]
    public required string Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    [Required]
    [DefaultValue(false)]
    public required bool IsGlobal { get; set; }
}