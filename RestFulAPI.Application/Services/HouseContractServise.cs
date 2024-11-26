using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class HouseContractServise(IHouseContract repo) : IHouseContractService
{
    public async Task<List<HouseContract>> GetAllAsync()
    {
        List<HouseContract> houseContracts = await repo.GetAllAsync();
        
        return houseContracts;
    }

    public async Task<HouseContract> GetByIdAsync(int id)
    {
        HouseContract houseContract = await repo.GetByIdAsync(id);
        
        return houseContract;
    }

    public async Task<int> AddAsync(HouseContract houseContract)
    {
        int res = await repo.AddAsync(houseContract);
        
        return res;
    }

    public async Task<int> UpdateAsync(HouseContract houseContract)
    {
        int res = await repo.UpdateAsync(houseContract);

        return res;
    }

    public async Task<int> DeleteAsync(int id)
    {
        int res = await repo.DeleteAsync(id);

        return res;
    }

    public async Task<List<HouseContract>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<HouseContract> houseContracts = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return houseContracts;
    }

    public async Task<List<HouseContract>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<HouseContract> houseContracts = await repo.GetFullByPageAsync(pageNumber, pageSize);
        
        return houseContracts;
    }

    public async Task<List<HouseContract>> GetByFilter(DateOnly startDate, DateOnly endDate)
    {
        List<HouseContract> houseContracts = await repo.GetByFilter(startDate, endDate);
        
        return houseContracts;
    }
}