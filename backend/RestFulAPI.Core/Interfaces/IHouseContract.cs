using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface IHouseContract
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

    public Task<List<HouseContract>> GetHouseContractByYearAndMonthAndHouseId(int houseId, int year, int month);
}