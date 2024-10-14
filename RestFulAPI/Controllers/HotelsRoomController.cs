using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsRoomController(HotelsRoomsService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<HotelsRoom>> Get()
    {
        return await middleware.GetHotelsRoomAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HotelsRoom>> Get(int id)
    {
        var hotelsRoom = await middleware.GetHotelsRoom(id);
        if (hotelsRoom == null)
        {
            return NotFound();
        }
        return hotelsRoom;
    }

    [HttpPost]
    public async Task<ActionResult<HotelsRoom>> Post([FromBody] HotelsRoom hotelsRoom)
    {
        if (hotelsRoom == null)
        {
            return BadRequest();
        }
        await middleware.AddHotelsRoom(hotelsRoom);
        return Ok(hotelsRoom);
    }

    [HttpPut]
    public async Task<ActionResult<HotelsRoom>> Put([FromBody] HotelsRoom hotelsRoom)
    {
        var res = await middleware.UpdateHotelsRoom(hotelsRoom);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(hotelsRoom);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<HotelsRoom>> Delete(int id)
    {
        var res = await middleware.DeleteHotelsRoom(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}