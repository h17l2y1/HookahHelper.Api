using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BrandController : ControllerBase
{
    // private readonly IIngredientService _service;
    //
    // public IngredientController(IIngredientService service)
    // {
    //     _service = service;
    // }

    [HttpGet]
    public async Task<IActionResult> GetById(string id)
    {
        // IngredientResponse response = await _service.GetById(id);
        // return Ok(response);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // IEnumerable<IngredientResponse> response = await _service.GetAll();
        // return Ok(response);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        // await _service.Create(request);
        // return Ok();
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update()
    {
        // await _service.Update(request);
        // return Ok();
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Remove(string id)
    {
        // await _service.Remove(id);
        // return Ok();
        return Ok();
    }
    
}