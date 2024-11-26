using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandLordController(ILandlordService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<Landlord>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Landlord>> GetSingle(int id)
    {
        var landLord = await service.GetByIdAsync(id);
        if (landLord == null)
        {
            return NotFound();
        }
        return landLord;
    }

    [HttpPut]
    public async Task<ActionResult<Landlord>> Put([FromBody] Landlord landLord)
    {
        if (landLord == null)
        {
            return BadRequest();
        }
        await service.AddAsync(landLord);
        return Ok(landLord);
    }

    [HttpPost]
    public async Task<ActionResult<Landlord>> Post([FromBody] Landlord landLord)
    {
        var res = await service.UpdateAsync(landLord);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(landLord);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Landlord>> Delete(int id)
    {
        var res = await service.DeleteAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}