using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services
{
    public class FlatImageService(IFlatImage repo) : IFlatImageService
    {
        public async Task<FlatImage> GetImageById(int id)
        {
            FlatImage flatImage = await repo.GetImageById(id);

            return flatImage;
        }
    }
}
