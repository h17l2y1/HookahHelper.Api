using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [HttpPost]
    public async Task<IActionResult> Register(SignUp model)
    {
        var user = new User
            { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password };
        var result = await _userManager.CreateAsync(user, model.Password);

        // if (result.Succeeded)
        // {
        //     await _signInManager.SignInAsync(user, isPersistent: false);
        // }
        return Ok();
    }
}