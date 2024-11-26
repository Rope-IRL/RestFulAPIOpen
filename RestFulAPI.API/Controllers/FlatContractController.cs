using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;


namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlatContractController(IFlatContractService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<FlatContract>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetInfoByPage(pageNumber, pageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FlatContract>> GetSingle(int id)
    {
        var contract = await service.GetFlatContractByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        return contract;
    }

    [HttpPut]
    public async Task<ActionResult<FlatContract>> Put([FromBody] FlatContract contract)
    {
        if (contract == null)
        {
            return BadRequest();
        }
        await service.AddFlatContractAsync(contract);
        return Ok(contract);
    }

    [HttpPost]
    public async Task<ActionResult<FlatContract>> Post([FromBody] FlatContract contract)
    {
        var res = await service.UpdateFlatContractAsync(contract);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(contract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<FlatContract>> Delete(int id)
    {
        var res = await service.DeleteFlatContractAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpGet("flat/filter/{id:int}")]
    public async Task<ActionResult<List<FlatContract>>> Filter(int id)
    {
        var res = await service.GetFlatContractsByFlatIdAsync(id);
        
        return res;
    }
}