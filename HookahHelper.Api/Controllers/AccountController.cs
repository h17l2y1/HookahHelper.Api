using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        LoginResponse token = await _service.Login(model);

        if (token != null)
        {
            return Ok(token);
        }
        return Unauthorized();
    }
    
    [HttpPost]
    public async Task<IActionResult> RefreshAuthToken([FromBody] RefreshTokenRequest request)
    {
        LoginResponse token = await _service.RefreshAuthToken(request);
        return Ok(token);
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public IActionResult IsAdmin()
    {
        return Ok();
    }
}