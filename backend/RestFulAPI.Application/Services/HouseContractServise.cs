using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class HouseContractService(IHouseContract repo) : IHouseContractService
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

    public async Task<List<HouseContract>> GetByLandlordId(int id)
    {
        List<HouseContract> houseContracts = await repo.GetByLandlordId(id);

        return houseContracts;
    }

    public async Task<List<HouseContract>> GetByLesseeId(int id)
    {
        List<HouseContract> houseContracts = await repo.GetByLesseeId(id);

        return houseContracts;
    }

    public async Task<HashSet<int>> GetHouseContractByYearAndMonthAndHouseId(int flatId, int year, int month)
    {
        int maxDay = DateTime.DaysInMonth(year, month);
        HashSet<int> notAvailableDays = new HashSet<int>();
        HashSet<int> availableDays = new HashSet<int>();
        List<HouseContract> contracts = await repo.GetHouseContractByYearAndMonthAndHouseId(flatId, year, month);


        foreach (HouseContract contract in contracts)
        {
            if (contract.StartDate.Month < month && contract.EndDate.Month == month)
            {
                for (int i = 1; i <= contract.EndDate.Day; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
            else if (contract.StartDate.Month == month && contract.EndDate.Month == month)
            {
                for (int i = contract.StartDate.Day; i <= contract.EndDate.Day; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
            else if (contract.StartDate.Month == month && contract.EndDate.Month > month)
            {
                for (int i = contract.StartDate.Day; i <= maxDay; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
        }

        for (int i = 1; i <= maxDay; i++)
        {
            if (!notAvailableDays.Contains(i))
            {
                availableDays.Add(i);
            }
        }

        return availableDays;
    }
}