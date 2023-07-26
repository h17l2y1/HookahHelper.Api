using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Line;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class LineController : ControllerBase
{
    private readonly ILineService _service;
    
    public LineController(ILineService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _service.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLineRequest request)
    {
        await _service.Create(request);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateLineRequest request)
    {
        await _service.Update(request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(string id)
    {
        await _service.Remove(id);
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLinesByBrandId(string id)
    {
        var response = await _service.GetLinesByBrandId(id);
        return Ok(response);
    }
}