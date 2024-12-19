using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces;

public interface IHouseContractService
{
    public Task<List<HouseContract>> GetAllAsync();
    
    public Task<HouseContract> GetByIdAsync(int id);
    
    public Task<int> AddAsync(HouseContract houseContract);
    
    public Task<int> UpdateAsync(HouseContract houseContract);
    
    public Task<int> DeleteAsync(int id);
    
    public Task<List<HouseContract>> GetByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<HouseContract>> GetFullByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<HouseContract>> GetByFilter(DateOnly startDate, DateOnly endDate);

    public Task<List<HouseContract>> GetByLandlordId(int id);

    public Task<List<HouseContract>> GetByLesseeId(int id);

    public Task<HashSet<int>> GetHouseContractByYearAndMonthAndHouseId(int flatId, int year, int month);

}