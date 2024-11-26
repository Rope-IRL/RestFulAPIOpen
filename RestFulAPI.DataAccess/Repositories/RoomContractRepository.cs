using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class RoomContractRepository(RentDbContext db) : IRoomContract
{
    public async Task<List<Core.Models.RoomContract>> GetAllRoomContractsAsync()
    {
        var roomContracts = await db.RoomContracts.ToListAsync();

        return roomContracts;
    }

    public async Task<Core.Models.RoomContract> GetRoomContractByIdAsync(int id)
    {
        var roomContractEntity = await db.RoomContracts.FirstOrDefaultAsync(room => room.Id == id);
        return roomContractEntity;
    }

    public async Task<int> AddRoomContractAsync(Core.Models.RoomContract roomContract)
    {
        await db.RoomContracts.AddAsync(roomContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> UpdateRoomContractAsync(Core.Models.RoomContract roomContract)
    {
        db.RoomContracts.Update(roomContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteRoomContractAsync(int id)
    {
        var roomContractEntity = await db.RoomContracts.FirstOrDefaultAsync(room => room.Id == id);
        db.RoomContracts.Remove(roomContractEntity);
        int res = await db.SaveChangesAsync();
        return res;
    }

    public async Task<List<RoomContract>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<RoomContract> roomContracts = await db.RoomContracts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return roomContracts;
    }

    public async Task<List<RoomContract>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<RoomContract> roomContracts = await db.RoomContracts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return roomContracts;
    }

    public async Task<List<RoomContract>> GetByFilter(DateOnly startDate, DateOnly endDate)
    {
        var q = db.RoomContracts.AsNoTracking();

        if (startDate != null)
        {
            q = q.Where(roomContract => roomContract.StartDate >= startDate);
        }

        if (endDate != null)
        {
            q = q.Where(roomContract => roomContract.EndDate <= endDate);
        }
        
        return await q.ToListAsync();
    }
}