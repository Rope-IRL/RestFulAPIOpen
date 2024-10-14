using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandLordAdditionalInfoController(LandLordsAdditionalInfoService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<LandLordsAdditionalInfo>> Get()
    {
        return await middleware.GetLandLordsAdditionalInfo();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LandLordsAdditionalInfo>> Get(int id)
    {
        var landLordAdditional = await middleware.GetLandLordAdditionalInfo(id);
        if (landLordAdditional == null)
        {
            return NotFound();
        }
        return landLordAdditional;
    }

    [HttpPost]
    public async Task<ActionResult<LandLordsAdditionalInfo>> Post([FromBody] LandLordsAdditionalInfo landLordAdditional)
    {
        if (landLordAdditional == null)
        {
            return BadRequest();
        }
        await middleware.AddLandLordsAdditionalInfo(landLordAdditional);
        return Ok(landLordAdditional);
    }

    [HttpPut]
    public async Task<ActionResult<LandLordsAdditionalInfo>> Put([FromBody] LandLordsAdditionalInfo landLordAdditional)
    {
        var res = await middleware.UpdateLandLordsAdditionalInfo(landLordAdditional);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(landLordAdditional);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<LandLordsAdditionalInfo>> Delete(int id)
    {
        var res = await middleware.DeleteLandLordAdditionalInfo(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}