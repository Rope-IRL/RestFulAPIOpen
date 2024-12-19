using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services
{
    public class HouseImageService(IHouseImage repo) : IHouseImageService
    {
        public async Task<HouseImage> GetImageById(int id)
        {
            HouseImage image = await repo.GetImageById(id);

            return image;
        }
    }
}
