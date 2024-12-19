
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces
{
    public interface IFlatImageService
    {
        public Task<FlatImage> GetImageById(int id);
    }
}
