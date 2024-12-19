using RestFulAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI.Core.Interfaces
{
    public interface IRoomImage
    {
        public Task<RoomImage> GetImageById(int id);
    }
}
