using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseImageController(IHouseImageService service) : Controller
    {

        [HttpGet("houseimages/{houseId:int}")]
        public async Task<ActionResult<HouseImage>> GetByFlatId(int houseId)
        {
            HouseImage images = await service.GetImageById(houseId);

            return Ok(images);
        }
    }
}
