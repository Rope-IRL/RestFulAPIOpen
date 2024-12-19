using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class FlatContractService(IFlatContract repo) : IFlatContractService
{
    public async Task<List<FlatContract>> GetFlatContractsAsync()
    {
        List<FlatContract> flatContracts = await repo.GetFlatContractsAsync();
        
        return flatContracts;
    }

    public async Task<FlatContract> GetFlatContractByIdAsync(int id)
    {
        FlatContract flatContract = await repo.GetFlatContractByIdAsync(id);
        
        return flatContract;
    }

    public async Task<int> AddFlatContractAsync(FlatContract flatContract)
    {
       int res =  await repo.AddFlatContractAsync(flatContract);

       return res;

    }

    public async Task<int> UpdateFlatContractAsync(FlatContract flatContract)
    {
        int res =  await repo.UpdateFlatContractAsync(flatContract);
        
        return res;
    }

    public async Task<int> DeleteFlatContractAsync(int id)
    {
        int res =  await repo.DeleteFlatContractAsync(id);
        
        return res;
    }

    public async Task<List<FlatContract>> GetInfoByPage(int pageNumber, int pageSize)
    {
        List<FlatContract> flatContracts = await repo.GetFullByPageAsync(pageNumber, pageSize);
        
        return flatContracts;
    }

    public async Task<List<FlatContract>> GetFlatContractByFilter(DateOnly startDate, DateOnly endDate)
    {
        List<FlatContract> flatContracts = await repo.GetByFilter(startDate, endDate);
        
        return flatContracts;
    }

    public async Task<List<FlatContract>> GetFlatContractsByFlatIdAsync(int flatId)
    {
        List<FlatContract> flatContracts = await repo.GetFlatContractsByFlatIdAsync(flatId);
        return flatContracts;
    }

    public async Task<List<FlatContract>> GetFlatContractsByLandlordIdAsync(int landlordId)
    {
        List<FlatContract> flatContracts = await repo.GetFlatContractsByLandlordIdAsync(landlordId);
        return flatContracts;
    }

    public async Task<List<FlatContract>> GetFlatContractsByLesseeIdAsync(int lessee)
    {
        List<FlatContract> flatContracts = await repo.GetFlatContractsByLesseeIdAsync(lessee);

        return flatContracts;
    }

    public async Task<HashSet<int>> GetFlatContractByYearAndMonthAndFlatId(int flatId, int year, int month)
    {
        int maxDay = DateTime.DaysInMonth(year, month);
        HashSet<int> notAvailableDays = new HashSet<int>();
        HashSet<int> availableDays = new HashSet<int>();
        List<FlatContract> contracts = await repo.GetFlatContractByYearAndMonthAndFlatId(flatId, year, month);


        foreach (FlatContract contract in contracts)
        {
            if(contract.StartDate.Month < month &&  contract.EndDate.Month == month)
            {
                for(int i = 1; i <= contract.EndDate.Day; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
            else if(contract.StartDate.Month == month && contract.EndDate.Month == month)
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

        for(int i = 1; i <= maxDay; i++)
        {
            if(!notAvailableDays.Contains(i))
            {
                availableDays.Add(i);
            }
        }

        return availableDays;
    }
}