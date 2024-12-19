using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Models;
using RestFulAPI.Core.Interfaces;

namespace RestFulAPI.DataAccess.Repositories;

public class FlatRepository(RentDbContext db) : IFlat
{
    public async Task<List<Core.Models.Flat>> GetAllFlatsAsync()
    {
        var flats = await db.Flats.ToListAsync();
        return flats;
    }

    public async Task<List<Core.Models.Flat>> GetAllFlatsFullAsync()
    {
        var flats = await db.Flats
            .Include(f => f.LandLord)
            .ThenInclude(l => l.AdditionalInfo)
            .ToListAsync();
        return flats;
    }

    public async Task<Core.Models.Flat> GetFlatAsync(int id)
    {
        var flat = await db.Flats.FirstOrDefaultAsync(f => f.Id == id);
        return flat;
    }

    public async Task<int> AddFlatAsync(Core.Models.Flat flat)
    {
        await db.Flats.AddAsync(flat);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> UpdateFlatAsync(Core.Models.Flat flat)
    {
        db.Flats.Update(flat);
        int res = await db.SaveChangesAsync();

        return res;
    }


    public async Task<int> DeleteFlatAsync(int id)
    {
        var flat = await db.Flats.FindAsync(id);
        db.Flats.Remove(flat);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Core.Models.Flat>> GetByPage(int pageSize, int pageNumber)
    {
        List<Core.Models.Flat> flats = await db.Flats
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return flats;
    }

    public async Task<List<Core.Models.Flat>> GetFullByPage(int pageSize, int pageNumber)
    {
        List<Core.Models.Flat> flats = await db.Flats
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return flats;
    }

    public async Task<List<Core.Models.Flat>> GetByFilter(string city, decimal averageCost)
    {
        var q = db.Flats.AsNoTracking();

        if (!string.IsNullOrEmpty(city)) q = q.Where(f => f.City == city);

        if (averageCost > 0) q = q.Where(flat => flat.CostPerDay > averageCost);

        return await q.ToListAsync();
    }

    public async Task<List<Flat>> GetByLandlord(int llId)
    {
        List<Flat> flats = await db.Flats.Where(f => f.LlId == llId).ToListAsync();

        return flats;
    }

    public async Task<List<Flat>> GetByDates(DateOnly startDate, DateOnly endDate)
    {
        List<Flat> flats = await db.Flats
            .Where(flat => !flat.Contracts.Any(contract => 
            contract.EndDate >=startDate && contract.StartDate <= endDate))
            .ToListAsync();

        return flats;
    }

    public async Task<List<Flat>> GetByCity(string city)
    {
        List<Flat> flats = await db.Flats
            .Where(flat => flat.City == city)
            .ToListAsync();

        return flats;
    }

    public async Task<List<Flat>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city)
    {
        List<Flat> flats = await db.Flats
            .Where(flat => flat.City == city && (!flat.Contracts.Any(contract =>
                contract.EndDate >= startDate && contract.StartDate <= endDate)))
            .ToListAsync();

        return flats;
    }

}
