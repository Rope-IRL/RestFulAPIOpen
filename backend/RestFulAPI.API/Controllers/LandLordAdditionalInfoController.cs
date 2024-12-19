using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;


namespace RestFulAPI.Controllers;

[Authorize(Roles = "landlord")]
[ApiController]
[Route("api/[controller]")]
public class LandLordAdditionalInfoController(ILandlordAdditionalInfoService service) : Controller
{
    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IEnumerable<LandlordAdditionalInfo>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LandlordAdditionalInfo>> GetSingle(int id)
    {

        var landLordAdditional = await service.GetAdditionalInfoByIdAsync(id);
        if (landLordAdditional == null)
        {
            return NotFound();
        }
        return landLordAdditional;
    }

    [HttpPut]
    public async Task<ActionResult<LandlordAdditionalInfo>> Put([FromBody] LandlordAdditionalInfo landLordAdditional)
    {
        if (landLordAdditional == null)
        {
            return BadRequest();
        }
        if(landLordAdditional.LandlordId == null)
        {
            int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
            landLordAdditional.LandlordId = userId;
        }
        await service.AddAdditionalInfoAsync(landLordAdditional);
        return Ok(landLordAdditional);
    }

    [HttpPost]
    public async Task<ActionResult<LandlordAdditionalInfo>> Post([FromBody] LandlordAdditionalInfo landLordAdditional)
    {
        var res = await service.UpdateAdditionalInfoAsync(landLordAdditional);
        if (res == 0)
        {
            return NotFound();
        }

        return Ok(landLordAdditional);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<LandlordAdditionalInfo>> Delete(int id)
    {
        var res = await service.DeleteAdditionalInfoAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}
