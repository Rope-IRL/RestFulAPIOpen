using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomContractController(IRoomContractService service) : Controller
{
    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IEnumerable<RoomContract>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomContract>> GetSingle(int id)
    {
        var roomsContract = await service.GetRoomContractByIdAsync(id);
        if (roomsContract == null)
        {
            return NotFound();
        }
        return roomsContract;
    }

    [HttpPut]
    public async Task<ActionResult<RoomContract>> Put([FromBody] RoomContract roomsContract)
    {
        if (roomsContract == null)
        {
            return BadRequest();
        }
        await service.AddRoomContractAsync(roomsContract);
        return Ok(roomsContract);
    }

    [HttpPost]
    public async Task<ActionResult<RoomContract>> Post([FromBody] RoomContract roomsContract)
    {
        var res = await service.UpdateRoomContractAsync(roomsContract);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(roomsContract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RoomContract>> Delete(int id)
    {
        var res = await service.DeleteRoomContractAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpGet("landlord/filter")]
    public async Task<ActionResult<List<RoomContract>>> GetContracts()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

        List<RoomContract> roomContracts = await service.GetByLandlordId(userId);

        return roomContracts;
    }

    [HttpGet("lessee/filter")]
    public async Task<ActionResult<List<RoomContract>>> GetLesseeContracts()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

        List<RoomContract> roomContracts = await service.GetByLesseeId(userId);

        return roomContracts;
    }

    [HttpGet("dates/{roomId:int}/{year:int}/{month:int}")]
    public async Task<ActionResult<HashSet<int>>> GetContractsByYearAndMonth(int roomId, int year, int month)
    {
        HashSet<int> roomContracts = await service.GetRoomContractByYearAndMonthAndRoomId(roomId, year, month);

        return roomContracts;
    }
}