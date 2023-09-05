using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Tag;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class TagController : ControllerBase
{
    private readonly ITagService _service;

    public TagController(ITagService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _service.GetById(id);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllRequest request)
    {
        var response = await _service.GetAll(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTagRequest request)
    {
        await _service.Create(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTagRequest request)
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
    
    [HttpGet]
    public async Task<IActionResult> GetOptions()
    {
        var response = await _service.GetOptions();
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetGlobalOptions()
    {
        var response = await _service.GetGlobalOptions();
        return Ok(response);
    }
}