using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace HookahHelper.BLL.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public async Task SignUp(SignUp model)
    {
        var user = new User
            { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password };
        var result = await _userManager.CreateAsync(user, model.Password);

        // if (result.Succeeded)
        // {
        //     await _signInManager.SignInAsync(user, isPersistent: false);
        // }
    }
}