using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HouseContractController(IHouseContractService service) : Controller
{
    [HttpGet("{pageNumber:int?}/{pageSize:int?}")]
    public async Task<IEnumerable<HouseContract>> Get(int pageNumber = 1, int pageSize = 20)
    {
        return await service.GetFullByPageAsync(pageNumber, pageSize);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HouseContract>> GetSingle(int id)
    {
        var contract = await service.GetByIdAsync(id);
        if (contract == null)
        {
            return NotFound();
        }
        return contract;
    }

    [HttpPut]
    public async Task<ActionResult<HouseContract>> Put([FromBody] HouseContract contract)
    {
        if (contract == null)
        {
            return BadRequest();
        }
        await service.AddAsync(contract);
        return Ok(contract);
    }

    [HttpPost]
    public async Task<ActionResult<HouseContract>> Post([FromBody] HouseContract contract)
    {
        var res = await service.UpdateAsync(contract);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok(contract);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<HouseContract>> Delete(int id)
    {
        var res = await service.DeleteAsync(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpGet("landlord/filter")]
    public async Task<ActionResult<List<HouseContract>>> GetContracts()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

        List<HouseContract> houseContracts = await service.GetByLandlordId(userId);

        return houseContracts;
    }

    [HttpGet("lessee/filter")]
    public async Task<ActionResult<List<HouseContract>>> GetLesseeContracts()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);

        List<HouseContract> houseContracts = await service.GetByLesseeId(userId);

        return houseContracts;
    }

    [HttpGet("dates/{houseId:int}/{year:int}/{month:int}")]
    public async Task<ActionResult<HashSet<int>>> GetContractsByYearAndMonth(int houseId, int year, int month)
    {
        HashSet<int> houseContracts = await service.GetHouseContractByYearAndMonthAndHouseId(houseId, year, month);

        return houseContracts;
    }
}