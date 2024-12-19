using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IRoomService service) : Controller
{
    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IEnumerable<Room>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetSingle(int id)
    {
        var hotelsRoom = await service.GetRoomByIdAsync(id);
        if (hotelsRoom == null)
        {
            return NotFound();
        }
        return hotelsRoom;
    }

    [HttpPut]
    public async Task<ActionResult<Room>> Put([FromBody] Room hotelsRoom)
    {
        if (hotelsRoom == null)
        {
            return BadRequest();
        }
        await service.AddRoomAsync(hotelsRoom);
        return Ok(hotelsRoom);
    }

    [HttpPost]
    public async Task<ActionResult<Room>> Post([FromBody] Room hotelsRoom)
    {
        var res = await service.UpdateRoomAsync(hotelsRoom);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(hotelsRoom);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Room>> Delete(int id)
    {
        var res = await service.DeleteRoomAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpGet("filter/{startDate:datetime}/{endDate:datetime}")]
    public async Task<ActionResult<List<Room>>> GetHousesByDates(DateOnly startDate, DateOnly endDate)
    {
        List<Room> rooms = await service.GetByDates(startDate, endDate);

        return rooms;
    }

    [HttpGet("filter/{city}")]
    public async Task<ActionResult<List<Room>>> GetHousesByCity(string city)
    {
        List<Room> rooms = await service.GetByCity(city);

        return rooms;
    }

    [HttpGet("filter/{city}/{startDate:datetime}/{endDate:datetime}")]
    public async Task<ActionResult<List<Room>>> GetHousesByCityAndDate(String city, DateOnly startDate, DateOnly endDate)
    {
        List<Room> rooms = await service.GetByDatesAndCity(startDate, endDate, city);

        return rooms;
    }
}