using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Default;

public record GetAllRequest
{
    [DefaultValue(0)]
    [Required]
    public int Page { get; set; }
    [DefaultValue(100)]
    [Required]
    public int Take { get; set; }
    [DefaultValue("asc")]
    [Required]
    public required string SortBy { get; set; }
    [DefaultValue("name")]
    [Required]
    public required string Column { get; set; }
    public string? FilterBy { get; set; }
}