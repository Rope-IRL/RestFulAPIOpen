using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LesseeAdditionalInfoController(LesseeAdditionalInfoService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<LesseesAdditionalInfo>> Get()
    {
        return await middleware.GetLesseesAdditionalInfo();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LesseesAdditionalInfo>> Get(int id)
    {
        var lesseeAdditional = await middleware.GetLesseeAdditionalInfo(id);
        if (lesseeAdditional == null)
        {
            return NotFound();
        }
        return lesseeAdditional;
    }

    [HttpPost]
    public async Task<ActionResult<LesseesAdditionalInfo>> Post([FromBody] LesseesAdditionalInfo lesseeAdditional)
    {
        if (lesseeAdditional == null)
        {
            return BadRequest();
        }
        await middleware.AddLesseeAdditionalInfo(lesseeAdditional);
        return Ok(lesseeAdditional);
    }

    [HttpPut]
    public async Task<ActionResult<LesseesAdditionalInfo>> Put([FromBody] LesseesAdditionalInfo lesseeAdditional)
    {
        var res = await middleware.UpdateLesseeAdditionalInfo(lesseeAdditional);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(lesseeAdditional);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<LesseesAdditionalInfo>> Delete(int id)
    {
        var res = await middleware.DeleteLesseeAdditionalInfo(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}