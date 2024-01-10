namespace HookahHelper.BLL.ViewModels.Account;

public record SignUp
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
}