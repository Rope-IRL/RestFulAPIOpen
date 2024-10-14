using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController(HotelService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<Hotel>> Get()
    {
        return await middleware.GetHotels();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> Get(int id)
    {
        var hotel = await middleware.GetHotel(id);
        if (hotel == null)
        {
            return NotFound();
        }
        return hotel;
    }

    [HttpPost]
    public async Task<ActionResult<Hotel>> Post([FromBody] Hotel hotel)
    {
        if (hotel == null)
        {
            return BadRequest();
        }
        await middleware.AddHotel(hotel);
        return Ok(hotel);
    }

    [HttpPut]
    public async Task<ActionResult<Hotel>> Put([FromBody] Hotel hotel)
    {
        var res = await middleware.UpdateHotel(hotel);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(hotel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Hotel>> Delete(int id)
    {
        var res = await middleware.DeleteHotel(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}