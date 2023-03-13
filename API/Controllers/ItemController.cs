using APP.Domain;
using APP.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _service;

    public ItemController(IItemService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Item>>> Get()
    {
        return Ok(await _service.GetAll());
    }
}