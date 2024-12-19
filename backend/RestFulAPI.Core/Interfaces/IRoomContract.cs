using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface IRoomContract
{
    public Task<List<RoomContract>> GetAllRoomContractsAsync();

    public Task<RoomContract> GetRoomContractByIdAsync(int id);

    public Task<int> AddRoomContractAsync(RoomContract roomContract);
    
    public Task<int> UpdateRoomContractAsync(RoomContract roomContract);
    
    public Task<int> DeleteRoomContractAsync(int id);
    
    public Task<List<RoomContract>> GetByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<RoomContract>> GetFullByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<RoomContract>> GetByFilter(DateOnly startDate, DateOnly endDate);

    public Task<List<RoomContract>> GetByLandlordId(int id);

    public Task<List<RoomContract>> GetByLesseeId(int id);

    public Task<List<RoomContract>> GetRoomContractByYearAndMonthAndRoomId(int roomId, int year, int month);

}