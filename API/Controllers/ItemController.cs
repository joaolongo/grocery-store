using System.Text.Json;
using System.Text.Json.Serialization;
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
        var items = await _service.GetAll();
        var response = items.Select(x => new
        {
            x.Id,
            x.Name,
            x.Price,
            HasOffer = x.SpecialOffer is not null
        });
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]Item item)
    {
        try
        {
            await _service.Create(item);
            
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}