using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Account;

public class RefreshTokenRequest
{
    [Required]
    public required string RefreshToken { get; set; }
}