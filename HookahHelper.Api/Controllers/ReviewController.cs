using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace HookahHelper.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReviewController: ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewRequest request)
    {
        await _service.Create(request);
        return Ok();
    }
}