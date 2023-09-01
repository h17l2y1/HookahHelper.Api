using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.Account;

public class SignUp
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}