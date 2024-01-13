using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Account;

public record Login
{
    [Required]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
}