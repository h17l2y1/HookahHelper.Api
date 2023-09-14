using Microsoft.AspNetCore.Identity;

namespace HookahHelper.DAL.Entities;

public class User : IdentityUser
{
    public User()
    {
        DateTime dateTime = DateTime.UtcNow;
        CreationDate = new DateTime(dateTime.Ticks - (dateTime.Ticks % TimeSpan.TicksPerSecond), dateTime.Kind);
    }

    public DateTime CreationDate { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }
}