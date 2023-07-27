using HookahHelper.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HeavinessController : ControllerBase
{
    private readonly IHeavinessService _service;

    public HeavinessController(IHeavinessService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOptions()
    {
        var response = await _service.GetOptions();
        return Ok(response);
    }
}