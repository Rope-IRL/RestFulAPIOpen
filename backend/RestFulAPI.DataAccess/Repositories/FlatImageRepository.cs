using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories
{
    public class FlatImageRepository(RentDbContext db) : IFlatImage
    {
        public async Task<FlatImage> GetImageById(int id)
        {
            FlatImage image = await db.FlatImages
                .FirstOrDefaultAsync(fi => fi.FlatId == id);
            return image;
        }
    }
}
