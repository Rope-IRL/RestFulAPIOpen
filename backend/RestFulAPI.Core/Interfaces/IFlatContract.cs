using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface IFlatContract
{
    public Task<List<FlatContract>> GetFlatContractsAsync();
    
    public Task<FlatContract> GetFlatContractByIdAsync(int id);
    
    public Task<int> AddFlatContractAsync(FlatContract flatContract);
    
    public Task<int> UpdateFlatContractAsync(FlatContract flatContract);
    
    public Task<int> DeleteFlatContractAsync(int id);

    public Task<List<FlatContract>> GetByPageAsync(int pageNumber, int pageSize);

    public Task<List<FlatContract>> GetFullByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<FlatContract>> GetByFilter(DateOnly startDate, DateOnly endDate);

    public  Task<List<FlatContract>> GetFlatContractsByFlatIdAsync(int flatId);

    public Task<List<FlatContract>> GetFlatContractsByLandlordIdAsync(int landlordId);

    public Task<List<FlatContract>> GetFlatContractsByLesseeIdAsync(int lessee);

    public Task<List<FlatContract>> GetFlatContractByYearAndMonthAndFlatId(int flatId, int year, int month);
}