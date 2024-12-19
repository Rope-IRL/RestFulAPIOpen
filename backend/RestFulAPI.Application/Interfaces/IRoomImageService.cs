using RestFulAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI.Application.Interfaces
{
    public interface IRoomImageService
    {
        public Task<RoomImage> GetImageById(int id);
    }
}
