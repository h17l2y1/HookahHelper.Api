namespace HookahHelper.DAL.Entities;

public class Country: BaseEntity
{
    public string Name { get; set; }
    public string BrandId { get; set; }
    
    public virtual Brand Brand { get; set; }
}