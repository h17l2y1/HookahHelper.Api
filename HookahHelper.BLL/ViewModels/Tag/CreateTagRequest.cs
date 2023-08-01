using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Tag;

public class CreateTagRequest
{
    [Required]
    public required string Name { get; set; }
}