using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Default;

public record GetAllRequest
{
    [DefaultValue(1)]
    [Required]
    public int Page { get; set; }
    [DefaultValue(100)]
    [Required]
    public int Take { get; set; }
    public string? SortBy { get; set; }
    public string? Column { get; set; }
}