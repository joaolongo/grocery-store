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
        return Ok(await _service.GetAll());
    }
}