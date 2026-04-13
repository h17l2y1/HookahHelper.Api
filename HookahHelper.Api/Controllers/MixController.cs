using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Mix;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MixController: ControllerBase
{
    private readonly IMixService _service;

    public MixController(IMixService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _service.GetById(id);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MixRequest request)
    {
        await _service.Create(request);
        return Ok();
    }
    
    [HttpGet]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllRequest request)
    {
        var response = await _service.GetAll(request);
        return Ok(response);
    }
} 