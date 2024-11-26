using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

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

    public async Task<List<House>> GetByPage(int pageSize, int pageNumber)
    {
        List<House> houses = await repo.GetByPage(pageSize, pageNumber);
        
        return houses;
    }

    public async Task<List<House>> GetFullByPage(int pageSize, int pageNumber)
    {
        List<House> houses = await repo.GetFullByPage(pageSize, pageNumber);
        
        return houses;
    }

    public async Task<List<House>> GetByFilter(string city, decimal averageCost)
    {
        List<House> houses = await repo.GetByFilter(city, averageCost);
        
        return houses;
    }
}