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

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUp request)
    {
        await _service.SignUp(request);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Login model)
    {
        LoginResponse token = await _service.Authenticate(model);

        if (token != null)
        {
            return Ok(token);
        }
        return Unauthorized();
    }
    
    [HttpPost]
    public async Task<IActionResult> RefreshAuthToken([FromBody] string refreshToken)
    {
        LoginResponse token = await _service.RefreshAuthToken(refreshToken);
        return Ok(token);
    }
}