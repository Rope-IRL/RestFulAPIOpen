using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LesseeAdditionalInfoController(ILesseeAdditionalInfoService service) : Controller
{
    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IEnumerable<LesseeAdditionalInfo>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LesseeAdditionalInfo>> GetSingle(int id)
    {
        var lesseeAdditional = await service.GetLesseeAdditionalInfoById(id);
        if (lesseeAdditional == null)
        {
            return NotFound();
        }
        return lesseeAdditional;
    }

    [HttpPut]
    public async Task<ActionResult<LesseeAdditionalInfo>> Put([FromBody] LesseeAdditionalInfo lesseeAdditional)
    {
        if (lesseeAdditional == null)
        {
            return BadRequest();
        }
        if (lesseeAdditional.LesseeId == null || lesseeAdditional.LesseeId == 0)
        {
            int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            lesseeAdditional.LesseeId = userId;
        }
        await service.AddLesseeAdditionalInfo(lesseeAdditional);
        return Ok(lesseeAdditional);
    }

    [HttpPost]
    public async Task<ActionResult<LesseeAdditionalInfo>> Post([FromBody] LesseeAdditionalInfo lesseeAdditional)
    {
        

        var res = await service.UpdateLesseeAdditionalInfo(lesseeAdditional);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(lesseeAdditional);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<LesseeAdditionalInfo>> Delete(int id)
    {
        var res = await service.DeleteLesseeAdditionalInfo(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}