using APP.Domain;
using APP.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController: ControllerBase
{
    private readonly IBasketService _service;

    public BasketController(IBasketService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Basket>>> Get()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public Task<IActionResult> Post()
    {
        throw new NotImplementedException();
    }
}