namespace HookahHelper.DAL.Entities;

public class RefreshToken : BaseEntity
{
    public required DateTime ExpiredDate { get; set; }
    public required string Token { get; set; }
    public required string UserId { get; set; }

    public virtual User User { get; set; }
}