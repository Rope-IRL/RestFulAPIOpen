using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;
using System.Runtime.InteropServices;

namespace RestFulAPI.Application.Services;

public class HouseService(IHouse repo) : IHouseService
{
    public async Task<List<House>> GetAllAsync()
    {
        List<House> houses = await repo.GetAllAsync();

        return houses;
    }

    public async Task<House> GetByIdAsync(int id)
    {
        House house = await repo.GetByIdAsync(id);

        return house;
    }

    public async Task<int> AddAsync(House house)
    {
        int res = await repo.AddAsync(house);

        return res;
    }

    public async Task<int> UpdateAsync(House house)
    {
        int res = await repo.UpdateAsync(house);

        return res;
    }

    public async Task<int> DeleteAsync(int id)
    {
        int res = await repo.DeleteAsync(id);

        return res;
    }

    public async Task<List<House>> GetByPage(int pageNumber, int pageSize)
    {
        List<House> houses = await repo.GetByPage(pageNumber, pageSize);

        return houses;
    }

    public async Task<List<House>> GetFullByPage(int pageNumber, int pageSize)
    {
        List<House> houses = await repo.GetFullByPage(pageNumber, pageSize);

        return houses;
    }

    public async Task<List<House>> GetByFilter(string city, decimal averageCost)
    {
        List<House> houses = await repo.GetByFilter(city, averageCost);

        return houses;
    }

    public async Task<List<House>> GetByLandlord(int llId)
    {
        List<House> houses = await repo.GetByLandlord(llId);

        return houses;
    }

    public async Task<List<House>> GetByDates(DateOnly startDate, DateOnly endDate)
    {
        List<House> houses = await repo.GetByDates(startDate, endDate);

        return houses;
    }

    public async Task<List<House>> GetByCity(string city)
    {
        List<House> houses = await repo.GetByCity(city);

        return houses;
    }

    public async Task<List<House>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city)
    {
        List<House> houses = await repo.GetByDatesAndCity(startDate, endDate, city);

        return houses;
    }
}
