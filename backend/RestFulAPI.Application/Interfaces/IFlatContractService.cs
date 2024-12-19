using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces;

public interface IFlatContractService
{
    public Task<List<FlatContract>> GetFlatContractsAsync();
    
    public Task<FlatContract> GetFlatContractByIdAsync(int id);
    
    public Task<int> AddFlatContractAsync(FlatContract flatContract);
    
    public Task<int> UpdateFlatContractAsync(FlatContract flatContract);
    
    public Task<int> DeleteFlatContractAsync(int id);
    
    public Task<List<FlatContract>> GetInfoByPage(int pageNumber, int pageSize);
    
    public Task<List<FlatContract>> GetFlatContractByFilter(DateOnly startDate, DateOnly endDate);

    public Task<List<FlatContract>> GetFlatContractsByFlatIdAsync(int flatId);

    public Task<List<FlatContract>> GetFlatContractsByLandlordIdAsync(int landlordId);

    public Task<List<FlatContract>> GetFlatContractsByLesseeIdAsync(int lessee);

    public Task<HashSet<int>> GetFlatContractByYearAndMonthAndFlatId(int flatId, int year, int month);
}