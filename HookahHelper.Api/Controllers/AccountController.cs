using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class AccountController : Controller
{
    private readonly IAccountService _service;
    
    public AccountController(IAccountService service)
    {
        _service = service;
    }

    // private readonly UserManager<User> _userManager;
    // private readonly SignInManager<User> _signInManager;
    //
    // public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    // {
    //     _userManager = userManager;
    //     _signInManager = signInManager;
    // }


    [HttpPost]
    public async Task<IActionResult> SignUp(SignUp request)
    {
        await _service.SignUp(request);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        var token = await _service.Authenticate(model);

        if (token != null)
        {
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }
}