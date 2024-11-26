using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlatController(IFlatService service): Controller
{

    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<ActionResult<List<Flat>>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFlats(pageNumber, pageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Flat>> GetSingle(int id)
    {
        var flat = await service.GetFlatById(id);
        if (flat == null)
        {
            return NotFound();
        }
        return flat;
    }

    [HttpPut]
    public async Task<ActionResult<Flat>> Put([FromBody] Flat flat)
    {
        if (flat == null)
        {
            return BadRequest();
        }
        await service.AddFlat(flat);
        return Ok(flat);
    }

    [HttpPost]
    public async Task<ActionResult<Flat>> Post([FromBody] Flat flat)
    {
        var res = await service.UpdateFlat(flat);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(flat);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Flat>> Delete(int id)
    {
        var res = await service.DeleteFlat(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}