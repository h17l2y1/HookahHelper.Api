namespace HookahHelper.DAL.Entities;

public class Tobacco: BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Sweetness { get; set; }
    public int Acidity { get; set; }
    public int Spice { get; set; }
    public int Freshness { get; set; }
    public int Rating { get; set; }
    public int Taste { get; set; }
    public int Fortress { get; set; }
    public int Smokiness { get; set; }
    public string? LineId { get; set; }
    public string? ImageId { get; set; }

    public virtual Line Line { get; set; }
    public virtual Image Image { get; set; }
}