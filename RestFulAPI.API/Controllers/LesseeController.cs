using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LesseeController(ILesseeService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<Lessee>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPage(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lessee>> GetSingle(int id)
    {
        var lessee = await service.GetLessee(id);
        if (lessee == null)
        {
            return NotFound();
        }
        return lessee;
    }

    [HttpPut]
    public async Task<ActionResult<Lessee>> Put([FromBody] Lessee lessee)
    {
        if (lessee == null)
        {
            return BadRequest();
        }
        await service.AddLessee(lessee);
        return Ok(lessee);
    }

    [HttpPost]
    public async Task<ActionResult<Lessee>> Post([FromBody] Lessee lessee)
    {
        var res = await service.UpdateLessee(lessee);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(lessee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Lessee>> Delete(int id)
    {
        var res = await service.DeleteLessee(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}