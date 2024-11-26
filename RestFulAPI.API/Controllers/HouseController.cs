using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseController(IHouseService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<House>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPage(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<House>> GetSingle(int id)
    {
        var house = await service.GetByIdAsync(id);
        if (house == null)
        {
            return NotFound();
        }
        return house;
    }

    [HttpPut]
    public async Task<ActionResult<House>> Put([FromBody] House house)
    {
        if (house == null)
        {
            return BadRequest();
        }
        await service.AddAsync(house);
        return Ok(house);
    }

    [HttpPost]
    public async Task<ActionResult<House>> Post([FromBody] House house)
    {
        var res = await service.UpdateAsync(house);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(house);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<House>> Delete(int id)
    {
        var res = await service.DeleteAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}