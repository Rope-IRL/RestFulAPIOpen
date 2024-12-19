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

    public async Task<List<HouseContract>> GetByLandlordId(int id)
    {
        List<HouseContract> houseContracts = await db.HouseContracts
        .Include(c => c.House)
        .Include(c => c.Landlord)
        .ThenInclude(ll => ll.AdditionalInfo)
        .Include(c => c.Lessee)
        .ThenInclude(l => l.AdditionalInfo)
        .Where(c => c.LandlordId == id).ToListAsync();

        return houseContracts;
    }

    public async Task<List<HouseContract>> GetByLesseeId(int id)
    {
        List<HouseContract> houseContracts = await db.HouseContracts
        .Include(c => c.House)
        .Include(c => c.Landlord)
        .ThenInclude(ll => ll.AdditionalInfo)
        .Include(c => c.Lessee)
        .ThenInclude(l => l.AdditionalInfo)
        .Where(c => c.LesseeId == id).ToListAsync();

        return houseContracts;
    }

    public async Task<List<HouseContract>> GetHouseContractByYearAndMonthAndHouseId(int houseId, int year, int month)
    {
        List<HouseContract> contracts = await db.HouseContracts
            .Where(fc => (fc.HouseId == houseId) && ((fc.StartDate.Year == year && fc.StartDate.Month == month) ||
                (fc.EndDate.Year == year && fc.EndDate.Month == month)))
            .OrderBy(fc => fc.StartDate)
            .ToListAsync();

        return contracts;
    }
}