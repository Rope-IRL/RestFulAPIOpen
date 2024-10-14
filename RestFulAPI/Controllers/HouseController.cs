using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseController(HouseService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<House>> Get()
    {
        return await middleware.GetHouses();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<House>> Get(int id)
    {
        var house = await middleware.GetHouse(id);
        if (house == null)
        {
            return NotFound();
        }
        return house;
    }

    [HttpPost]
    public async Task<ActionResult<House>> Post([FromBody] House house)
    {
        if (house == null)
        {
            return BadRequest();
        }
        await middleware.AddHouse(house);
        return Ok(house);
    }

    [HttpPut]
    public async Task<ActionResult<House>> Put([FromBody] House house)
    {
        var res = await middleware.UpdateHouse(house);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(house);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<House>> Delete(int id)
    {
        var res = await middleware.DeleteHouse(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}