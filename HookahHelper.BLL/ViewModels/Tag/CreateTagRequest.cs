using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tag;

public record CreateTagRequest
{
    [Required]
    public required string Name { get; set; }
    [Required]
    [DefaultValue(false)]
    public required bool IsGlobal { get; set; }
}