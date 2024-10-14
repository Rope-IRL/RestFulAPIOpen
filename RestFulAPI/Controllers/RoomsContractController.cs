using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsContractController(RoomsContractService controller) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<RoomsContract>> Get()
    {
        return await controller.GetRoomsContractsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomsContract>> Get(int id)
    {
        var roomsContract = await controller.GetRoomsContract(id);
        if (roomsContract == null)
        {
            return NotFound();
        }
        return roomsContract;
    }

    [HttpPost]
    public async Task<ActionResult<RoomsContract>> Post([FromBody] RoomsContract roomsContract)
    {
        if (roomsContract == null)
        {
            return BadRequest();
        }
        await controller.AddRoomsContract(roomsContract);
        return Ok(roomsContract);
    }

    [HttpPut]
    public async Task<ActionResult<RoomsContract>> Put([FromBody] RoomsContract roomsContract)
    {
        var res = await controller.UpdateRoomsContract(roomsContract);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(roomsContract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RoomsContract>> Delete(int id)
    {
        var res = await controller.DeleteRoomsContract(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}