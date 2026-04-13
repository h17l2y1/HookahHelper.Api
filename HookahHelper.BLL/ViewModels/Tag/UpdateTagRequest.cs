using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tag;

public record UpdateTagRequest
{
    [Required]
    public required int id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    [Required]
    public required string Color { get; set; }
    
    [Required]
    [DefaultValue(false)]
    public required bool IsGlobal { get; set; }
}