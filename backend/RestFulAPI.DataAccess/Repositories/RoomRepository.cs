using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class RoomRepository(RentDbContext db) : IRoom
{
    public async Task<List<Core.Models.Room>> GetAllRoomsAsync()
    {
        var rooms = await db.Rooms.ToListAsync();

        return rooms;
    }

    public async Task<Core.Models.Room> GetRoomByIdAsync(int id)
    {
        var roomEntity = await db.Rooms.FirstOrDefaultAsync(room => room.Id == id);
        return roomEntity;
    }

    public async Task<int> AddRoomAsync(Core.Models.Room room)
    {
        await db.Rooms.AddAsync(room);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> UpdateRoomAsync(Core.Models.Room room)
    {
        db.Rooms.Update(room);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteRoomAsync(int id)
    {
        var roomEntity = db.Rooms.FirstOrDefault(room => room.Id == id);
        db.Rooms.Remove(roomEntity);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Room>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<Room> rooms = await db.Rooms
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return rooms;
    }

    public async Task<List<Room>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<Room> rooms = await db.Rooms
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return rooms;
    }

    public async Task<List<Room>> GetByFilter(decimal costPerDay)
    {
        var q = db.Rooms.AsNoTracking();

        if (costPerDay > 0)
        {
            q = q.Where(r => r.CostPerDay >= costPerDay);
        }
        
        return await q.ToListAsync();
    }

    public async Task<List<Room>> GetByHotelId(int id)
    {
        List<Room> rooms = await db.Rooms.Where(r => r.HotelId == id).ToListAsync();

        return rooms;
    }

    public async Task<List<Room>> GetByDates(DateOnly startDate, DateOnly endDate)
    {
        List<Room> rooms = await db.Rooms
            .Where(room => !room.Contracts.Any(contract =>
                contract.EndDate >= startDate && contract.StartDate <= endDate))
            .ToListAsync();

        return rooms;
    }

    public async Task<List<Room>> GetByCity(string city)
    {
        List<Room> rooms = await db.Rooms
            .Where(room => room.Hotel.City == city)
            .ToListAsync();

        return rooms;
    }

    public async Task<List<Room>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city)
    {
        List<Room> rooms = await db.Rooms
            .Where(room => room.Hotel.City == city && (!room.Contracts.Any(contract =>
                contract.EndDate >= startDate && contract.StartDate <= endDate)))
            .ToListAsync();

        return rooms;
    }

}