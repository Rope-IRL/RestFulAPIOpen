
using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces
{
    public interface IFlatImage
    {
        public Task<FlatImage> GetImageById(int id);
    }
}
