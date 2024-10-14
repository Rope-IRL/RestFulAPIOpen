using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LesseeController(LesseeService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<Lessee>> Get()
    {
        return await middleware.GetLessees();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lessee>> Get(int id)
    {
        var lessee = await middleware.GetLessee(id);
        if (lessee == null)
        {
            return NotFound();
        }
        return lessee;
    }

    [HttpPost]
    public async Task<ActionResult<Lessee>> Post([FromBody] Lessee lessee)
    {
        if (lessee == null)
        {
            return BadRequest();
        }
        await middleware.AddLessee(lessee);
        return Ok(lessee);
    }

    [HttpPut]
    public async Task<ActionResult<Lessee>> Put([FromBody] Lessee lessee)
    {
        var res = await middleware.UpdateLessee(lessee);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(lessee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Lessee>> Delete(int id)
    {
        var res = await middleware.DeleteLessee(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}