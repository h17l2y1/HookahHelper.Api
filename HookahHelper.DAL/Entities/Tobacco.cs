using System.ComponentModel.DataAnnotations; 

namespace HookahHelper.DAL.Entities;

public class Tobacco: BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Range(0, 5)]
    public float Sweetness { get; set; }
    [Range(0, 5)]
    public float Acidity { get; set; }
    [Range(0, 5)]
    public float Spice { get; set; }
    [Range(0, 5)]
    public float Freshness { get; set; }
    [Range(0, 5)]
    public float Rating { get; set; }
    [Range(0, 5)]
    public float Taste { get; set; }
    [Range(0, 5)]
    public float Fortress { get; set; }
    [Range(0, 5)]
    public float Smokiness { get; set; }
    [Range(0, 5)]
    public string? LineId { get; set; }
    [Range(0, 5)]
    public string? ImageId { get; set; }

    public virtual Line Line { get; set; }
    public virtual Image Image { get; set; }
}