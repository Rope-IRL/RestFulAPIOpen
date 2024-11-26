using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services
{
    public class FlatService(IFlat repo) : IFlatService
    {
        public async Task<List<Flat>> GetFlats(int pageNumber, int pageSize)
        {
            List<Flat> flats = await repo.GetByPage(pageSize, pageNumber);

            //check if null

            return flats;
        }

        public async Task<List<Flat>> GetFullFlats(int pageNumber, int pageSize)
        {
            List<Flat> flats = await repo.GetFullByPage(pageSize, pageNumber);

            //check if null

            return flats;
        }

        public async Task<Flat> GetFlatById(int id)
        {
            Flat flat = await repo.GetFlatAsync(id);

            return flat;
        }

        public async Task<int> AddFlat(Flat flat)
        {
            int res = await repo.AddFlatAsync(flat);

            return res;
        }

        public async Task<int> UpdateFlat(Flat flat)
        {
           int res =  await repo.UpdateFlatAsync(flat);

           return res;
        }

        public async Task<int> DeleteFlat(int id)
        {
            int res = await repo.DeleteFlatAsync(id);

            return res;
        }

        public async Task<List<Flat>> GetFlatsByFilter(string city, decimal averageCost)
        {
            List<Flat> flats = await repo.GetByFilter(city, averageCost);
            return flats;
        }

    }
}
