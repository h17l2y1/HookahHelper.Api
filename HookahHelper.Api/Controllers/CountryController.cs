using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Country;
using HookahHelper.BLL.ViewModels.Default;

using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class CountryController : ControllerBase
{
    private readonly ICountryService _service;
    
    public CountryController(ICountryService service)
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
    public async Task<IActionResult> Create(CreateCountryRequest request)
    {
        await _service.Create(request);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCountryRequest request)
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