using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class FlatContractRepository(RentDbContext db) : IFlatContract
{
    public async Task<List<Core.Models.FlatContract>> GetFlatContractsAsync()
    {
        var flatContracts = await db.FlatContracts.ToListAsync();
        return flatContracts;
    }

    public async Task<Core.Models.FlatContract> GetFlatContractByIdAsync(int id)
    {
        var flatContract = await db.FlatContracts.FirstOrDefaultAsync(flat => flat.Id == id);

        return flatContract;
    }

    public async Task<int> AddFlatContractAsync(Core.Models.FlatContract flatContract)
    {
        await db.FlatContracts.AddAsync(flatContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> UpdateFlatContractAsync(Core.Models.FlatContract flatContract)
    {
        db.FlatContracts.Update(flatContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteFlatContractAsync(int id)
    {
        var flatContract = await db.FlatContracts.FirstOrDefaultAsync(flat => flat.Id == id);
        db.FlatContracts.Remove(flatContract);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Core.Models.FlatContract>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<FlatContract> flatContracts = await db.FlatContracts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return flatContracts;
    }

    public async Task<List<Core.Models.FlatContract>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<FlatContract> flatContracts = await db.FlatContracts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return flatContracts;
    }

    public async Task<List<Core.Models.FlatContract>> GetByFilter(DateOnly startDate, DateOnly endDate)
    {
        var q = db.FlatContracts.AsNoTracking();
        if (startDate != null)
        {
            q = q.Where(flat => flat.StartDate >= startDate);
        }
        
        if (endDate != null)
        {
            q = q.Where(flat => flat.EndDate >= endDate);
        }
        
        return await q.ToListAsync();
    }

    public async Task<List<FlatContract>> GetFlatContractsByFlatIdAsync(int flatId)
    {
        List<FlatContract> contracts = await db.FlatContracts.Where(c => c.FlatId == flatId).ToListAsync();
        
       return contracts; 
    }

    public async Task<List<FlatContract>> GetFlatContractsByLandlordIdAsync(int landlordId)
    {
        List<FlatContract> contracts = await db.FlatContracts
        .Include(c => c.Flat)
        .Include(c => c.Landlord)
        .ThenInclude(ll => ll.AdditionalInfo)
        .Include(c => c.Lessee)
        .ThenInclude(l => l.AdditionalInfo)
        .Where(c => c.LandlordId == landlordId).ToListAsync();
        
       return contracts; 
    }

    public async Task<List<FlatContract>> GetFlatContractsByLesseeIdAsync(int lessee)
    {
        List<FlatContract> contracts = await db.FlatContracts
        .Include(c => c.Flat)
        .Include(c => c.Landlord)
        .ThenInclude(ll => ll.AdditionalInfo)
        .Include(c => c.Lessee)
        .ThenInclude(l => l.AdditionalInfo)
        .Where(c => c.LesseeId == lessee).ToListAsync();

        return contracts;
    }

    public async Task<List<FlatContract>> GetFlatContractByYearAndMonthAndFlatId(int flatId, int year, int month)
    {
        List<FlatContract> contracts = await db.FlatContracts
            .Where(fc => (fc.FlatId == flatId) && ((fc.StartDate.Year == year && fc.StartDate.Month == month) ||
                (fc.EndDate.Year == year && fc.EndDate.Month == month)))
            .OrderBy(fc => fc.StartDate)
            .ToListAsync();

        return contracts;
    }
}