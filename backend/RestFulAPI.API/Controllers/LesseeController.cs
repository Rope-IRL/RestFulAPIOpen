using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Application.DTOs;
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
        if (Request.Cookies.ContainsKey(".AspNetCore.Application.Id"))
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
        }
        var res = await service.DeleteLessee(id);
        if (res == 0)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<LesseeDTO>> Auth([FromBody] LesseeDTO landlordDTO)
    {

        LesseeDTO lesseeDTO = await service.GetToken(landlordDTO);

        string token = lesseeDTO.Token;

        if (token == null)
        {
            return Unauthorized();
        }
        
        HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token, new CookieOptions
        {
            MaxAge = TimeSpan.FromMinutes(60)
        });

        return Ok(lesseeDTO);
    }
    
    [HttpGet]
    [Route("refreshToken")]
    [Authorize(Roles = "lessee")]
    public async Task<ActionResult<LesseeDTO>> RefreshToken()
    {
        int userId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id").Value);
        if(userId == 0)
        {
            return NotFound();

        }
        Lessee lessee = await service.GetLessee(userId);
        LesseeDTO lesseeDTO = new LesseeDTO
        {
            Id = lessee.Id,
            Email = lessee.Email,
            Login = lessee.Login,
            Password = lessee.HashedPassword,
            Name = lessee.AdditionalInfo == null ? lessee.Email : lessee.AdditionalInfo.Name
            
        };

        return Ok(lesseeDTO);
    }

    [HttpGet]
    [Route("logout")]
    [Authorize(Roles ="lessee")]
    public async Task<ActionResult> LogOut()
    {
        if (Request.Cookies.ContainsKey(".AspNetCore.Application.Id"))
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
        }

        return Ok();
    }
}