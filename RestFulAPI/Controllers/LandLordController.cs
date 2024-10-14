using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandLordController(LandLordService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<LandLord>> Get()
    {
        return await middleware.GetLandLords();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LandLord>> Get(int id)
    {
        var landLord = await middleware.GetLandLord(id);
        if (landLord == null)
        {
            return NotFound();
        }
        return landLord;
    }

    [HttpPost]
    public async Task<ActionResult<LandLord>> Post([FromBody] LandLord landLord)
    {
        if (landLord == null)
        {
            return BadRequest();
        }
        await middleware.AddLandLord(landLord);
        return Ok(landLord);
    }

    [HttpPut]
    public async Task<ActionResult<LandLord>> Put([FromBody] LandLord landLord)
    {
        var res = await middleware.UpdateLandLord(landLord);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(landLord);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<LandLord>> Delete(int id)
    {
        var res = await middleware.DeleteLandLord(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}