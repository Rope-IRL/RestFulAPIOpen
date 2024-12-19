
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services
{
    public class RoomImageService(IRoomImage repo) : IRoomImageService
    {
        public async Task<RoomImage> GetImageById(int id)
        {
            RoomImage roomImage = await repo.GetImageById(id);

            return roomImage;
        }
    }
}
