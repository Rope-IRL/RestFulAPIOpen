using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces
{
    public interface IFlatService
    {
        public Task<List<Flat>> GetFlats(int pageNumber, int pageSize);

        public Task<List<Flat>> GetFullFlats(int pageNumber, int pageSize);

        public Task<Flat> GetFlatById(int id);

        public Task<int> AddFlat(Flat flat);

        public Task<int> UpdateFlat(Flat flat);

        public Task<int> DeleteFlat(int id);

        public Task<List<Flat>> GetFlatsByFilter(string city, decimal averageCost);

        public Task<List<Flat>> GetByLandlord(int llId);

        public Task<List<Flat>> GetByDates(DateOnly startDate, DateOnly endDate);

        public Task<List<Flat>> GetByCity(string city);

        public Task<List<Flat>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city);
    }
}
