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
}