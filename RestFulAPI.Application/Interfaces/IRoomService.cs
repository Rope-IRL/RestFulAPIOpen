using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces;

public interface IRoomService
{
    public Task<List<Room>> GetAllRoomsAsync();
    
    public Task<Room> GetRoomByIdAsync(int id);
    
    public Task<int> AddRoomAsync(Room room);
    
    public Task<int> UpdateRoomAsync(Room room);
    
    public Task<int> DeleteRoomAsync(int id);
    
    public Task<List<Room>> GetByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<Room>> GetFullByPageAsync(int pageNumber, int pageSize);

    public Task<List<Room>> GetByFilter(decimal costPerDay);
}