using APP.Domain;
using APP.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecialOfferController : ControllerBase
{
    private readonly ISpecialOfferService _service;

    public SpecialOfferController(ISpecialOfferService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<SpecialOffer>>> Get()
    {
        var offers = await _service.GetAll();

        var result = offers.Select(x => new
        {
            x.Id,
            ItemId = x.Item.Id,
            x.Description,
            x.Percentage,
            x.RequiredAmount,
            DiscountItemId = x.DiscountItem?.Id
        });
        
        return Ok(result);
    }
}