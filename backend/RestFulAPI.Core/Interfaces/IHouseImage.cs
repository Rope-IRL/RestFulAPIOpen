using RestFulAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI.Core.Interfaces
{
    public interface IHouseImage
    {
        public Task<HouseImage> GetImageById(int id);
    }
}
