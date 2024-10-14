using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using RestFulAPI.Services;


namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlatsContractController(FlatsContractService middleware) : Controller
{
    [HttpGet]
    public async Task<IEnumerable<FlatsContract>> Get()
    {
        return await middleware.GetFlatsContractsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FlatsContract>> Get(int id)
    {
        var contract = await middleware.GetFlatsContract(id);
        if (contract == null)
        {
            return NotFound();
        }
        return contract;
    }

    [HttpPost]
    public async Task<ActionResult<FlatsContract>> Post([FromBody] FlatsContract contract)
    {
        if (contract == null)
        {
            return BadRequest();
        }
        await middleware.AddFlatsContract(contract);
        return Ok(contract);
    }

    [HttpPut]
    public async Task<ActionResult<FlatsContract>> Put([FromBody] FlatsContract contract)
    {
        var res = await middleware.UpdateFlatsContract(contract);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(contract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<FlatsContract>> Delete(int id)
    {
        var res = await middleware.DeleteFlatsContract(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }
}