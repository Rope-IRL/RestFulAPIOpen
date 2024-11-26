using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class HouseContractRepository(RentDbContext db) : IHouseContract
{
    public async Task<List<Core.Models.HouseContract>> GetAllAsync()
    {
        var houseContracts = await db.HouseContracts.ToListAsync();
        return houseContracts;
    }

    public async Task<Core.Models.HouseContract> GetByIdAsync(int id)
    {
        var houseContract = await db.HouseContracts.FirstOrDefaultAsync(house => house.Id == id);
        return houseContract;
    }

    public async Task<int> AddAsync(Core.Models.HouseContract houseContract)
    {
        await db.HouseContracts.AddAsync(houseContract);
        int res = await db.SaveChangesAsync();

        return res;

    }

    public async Task<int> UpdateAsync(Core.Models.HouseContract houseContract)
    {
        db.HouseContracts.Update(houseContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var houseContract = await db.HouseContracts.FirstOrDefaultAsync(house => house.Id == id);
        db.HouseContracts.Remove(houseContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<HouseContract>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<HouseContract> houseContracts = await db.HouseContracts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return houseContracts;
    }

    public async Task<List<HouseContract>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<HouseContract> houseContracts = await db.HouseContracts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return houseContracts;
    }

    public async Task<List<HouseContract>> GetByFilter(DateOnly startDate, DateOnly endDate)
    {
        var q = db.HouseContracts.AsNoTracking();

        if (startDate != null)
        {
            q = q.Where(h => h.StartDate >= startDate);
        }

        if (endDate != null)
        {
            q = q.Where(h => h.EndDate <= endDate);
        }
        
        return await q.ToListAsync();
    }
}