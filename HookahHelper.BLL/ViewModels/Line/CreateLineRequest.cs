using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HookahHelper.DAL.Entities.Enums;

namespace HookahHelper.BLL.ViewModels.Line;

public class CreateLineRequest
{
    [Required]
    public required string Name { get; set; }
    [DefaultValue("")]
    public string? Description { get; set; }
    public HeavinessType Heaviness { get; set; }
    [Required]
    public required string BrandId { get; set; }
}