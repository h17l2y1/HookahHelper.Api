using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Default;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _service;
    
    public BrandController(IBrandService service)
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
    
    [HttpGet]
    public async Task<IActionResult> GetOptions()
    {
        var response = await _service.GetOptions();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandRequest request)
    {
        await _service.Create(request);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateBrandRequest request)
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