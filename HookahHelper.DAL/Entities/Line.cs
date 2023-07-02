using HookahHelper.DAL.Entities.Enums;

namespace HookahHelper.DAL.Entities;

public class Line: BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public HeavinessType Heaviness { get; set; }
    public string BrandId { get; set; }

    public virtual Brand Brand { get; set; }
}