using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class RoomService(IRoom repo) : IRoomService
{
    public async Task<List<Room>> GetAllRoomsAsync()
    {
        List<Room> rooms = await repo.GetAllRoomsAsync();
        
        return rooms;
    }

    public async Task<Room> GetRoomByIdAsync(int id)
    {
        Room room = await repo.GetRoomByIdAsync(id);
        
        return room;
    }

    public async Task<int> AddRoomAsync(Room room)
    {
        int res = await repo.AddRoomAsync(room);
        
        return res;
    }

    public async Task<int> UpdateRoomAsync(Room room)
    {
        int res = await repo.UpdateRoomAsync(room);
        
        return res;
    }

    public async Task<int> DeleteRoomAsync(int id)
    {
        int res = await repo.DeleteRoomAsync(id);
        
        return res;
    }

    public async Task<List<Room>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<Room> rooms = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return rooms;
    }

    public async Task<List<Room>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<Room> rooms = await repo.GetFullByPageAsync(pageNumber, pageSize);
        
        return rooms;
    }

    public async Task<List<Room>> GetByFilter(decimal costPerDay)
    {
        List<Room> rooms = await repo.GetByFilter(costPerDay);
        
        return rooms;
    }

    public async Task<List<Room>> GetByDates(DateOnly startDate, DateOnly endDate)
    {
        List<Room> rooms = await repo.GetByDates(startDate, endDate);

        return rooms;
    }

    public async Task<List<Room>> GetByCity(string city)
    {
        List<Room> rooms = await repo.GetByCity(city);

        return rooms;
    }

    public async Task<List<Room>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city)
    {
        List<Room> rooms = await repo.GetByDatesAndCity(startDate, endDate, city);

        return rooms;
    }
}