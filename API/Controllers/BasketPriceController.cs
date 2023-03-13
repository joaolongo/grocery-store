using APP.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/basket/[controller]")]
public class BasketPriceController : ControllerBase
{
    private readonly IBasketService _service;

    public BasketPriceController(IBasketService service)
    {
        _service = service;
    }

    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<string>> Get(Guid id)
    {
        var result = await _service.GetPrice(id);
        
        return Ok(result);
    }
}