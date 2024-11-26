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
            .Include(r => r.Hotel)
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
}