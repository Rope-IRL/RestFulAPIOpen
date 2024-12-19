using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories
{
    public class HouseImageRepository(RentDbContext db) : IHouseImage
    {
        public async Task<HouseImage> GetImageById(int id)
        {
            HouseImage image = await db.HouseImages
                .FirstOrDefaultAsync(fi => fi.HouseId == id);

            return image;
        }
    }
}
