using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlatsController(FlatsService middleware): Controller
{
    [HttpGet]
    public async Task<IEnumerable<Flat>> Get()
    {
        return await middleware.GetFlats();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Flat>> Get(int id)
    {
        var flat = await middleware.GetFlat(id);
        if (flat == null)
        {
            return NotFound();
        }
        return flat;
    }

    [HttpPost]
    public async Task<ActionResult<Flat>> Post([FromBody] Flat flat)
    {
        if (flat == null)
        {
            return BadRequest();
        }
        await middleware.AddFlat(flat);
        return Ok(flat);
    }

    [HttpPut]
    public async Task<ActionResult<Flat>> Put([FromBody] Flat flat)
    {
        var res = await middleware.UpdateFlat(flat);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(flat);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Flat>> Delete(int id)
    {
        var res = await middleware.DeleteFlat(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}