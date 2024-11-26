using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController(IHotelService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<ActionResult<IEnumerable<Hotel>>> Get(int pageNumber = 1, int pageSize = 20)
    {
        var res = await service.GetFullByPageAsync(pageNumber, pageSize);
        return res;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> GetSingle(int id)
    {
        var hotel = await service.GetHotelById(id);
        if (hotel == null)
        {
            return NotFound();
        }
        return hotel;
    }

    [HttpPut]
    public async Task<ActionResult<Hotel>> Put([FromBody] Hotel hotel)
    {
        if (hotel == null)
        {
            return BadRequest();
        }
        await service.AddHotel(hotel);
        return Ok(hotel);
    }

    [HttpPost]
    public async Task<ActionResult<Hotel>> Post([FromBody] Hotel hotel)
    {
        var res = await service.UpdateHotel(hotel);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(hotel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Hotel>> Delete(int id)
    {
        var res = await service.DeleteHotel(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}