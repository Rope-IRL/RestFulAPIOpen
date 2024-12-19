using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI.DataAccess.Repositories
{
    public class RoomImageRepository(RentDbContext db) : IRoomImage
    {
        public async Task<RoomImage> GetImageById(int id)
        {
            RoomImage image = await db.RoomImages
                .FirstOrDefaultAsync(fi => fi.RoomId == id);
            return image;
        }
    }
}
