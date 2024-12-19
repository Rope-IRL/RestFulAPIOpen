using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface IHouse
{
    public Task<List<House>> GetAllAsync();

    public Task<House> GetByIdAsync(int id);

    public Task<int> AddAsync(House house);

    public Task<int> UpdateAsync(House house);

    public Task<int> DeleteAsync(int id);

    public Task<List<House>> GetByPage(int pageSize, int pageNumber);

    public Task<List<House>> GetFullByPage(int pageSize, int pageNumber);

    public Task<List<House>> GetByFilter(string city, decimal averageCost);

    public Task<List<House>> GetByLandlord(int llId);

    public Task<List<House>> GetByDates(DateOnly startDate, DateOnly endDate);

    public Task<List<House>> GetByCity(string city);

    public Task<List<House>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city);
}
