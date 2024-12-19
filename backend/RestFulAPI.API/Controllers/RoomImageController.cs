using Microsoft.AspNetCore.Mvc;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomImageController(IRoomImageService service) : Controller
    {

        [HttpGet("roomimages/{roomId:int}")]
        public async Task<ActionResult<RoomImage>> GetByFlatId(int roomId)
        {
            RoomImage images = await service.GetImageById(roomId);

            return Ok(images);
        }
    }
}
