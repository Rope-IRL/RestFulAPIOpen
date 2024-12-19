
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces
{
    public interface IHouseImageService
    {
        public Task<HouseImage> GetImageById(int id);
    }
}
