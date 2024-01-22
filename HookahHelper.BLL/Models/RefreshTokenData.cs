namespace HookahHelper.BLL.Models;

public record RefreshTokenData
{
    public required DateTime ExpiredDate { get; set; }
    public required string UserId { get; set; }
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}