using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Image;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]

public class ImageController:ControllerBase
{
    private readonly IImageService _service;
    
    public ImageController(IImageService service)
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
    public async Task<IActionResult> Create(CreateImageRequest request)
    {
        await _service.Create(request);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateImageRequest request)
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
}