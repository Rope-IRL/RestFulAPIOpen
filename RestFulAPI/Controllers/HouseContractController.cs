using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Services;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseContractController(HouseContractService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<HousesContract>> Get()
    {
        return await middleware.GetHousesContractsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HousesContract>> Get(int id)
    {
        var contract = await middleware.GetHousesContract(id);
        if (contract == null)
        {
            return NotFound();
        }
        return contract;
    }

    [HttpPost]
    public async Task<ActionResult<HousesContract>> Post([FromBody] HousesContract contract)
    {
        if (contract == null)
        {
            return BadRequest();
        }
        await middleware.AddHousesContract(contract);
        return Ok(contract);
    }

    [HttpPut]
    public async Task<ActionResult<HousesContract>> Put([FromBody] HousesContract contract)
    {
        var res = await middleware.UpdateHousesContract(contract);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(contract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<HousesContract>> Delete(int id)
    {
        var res = await middleware.DeleteHousesContract(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}