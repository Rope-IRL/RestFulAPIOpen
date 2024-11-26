using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class HouseRepository(RentDbContext db) : IHouse
{
    public async Task<List<Core.Models.House>> GetAllAsync()
    {
        var houses = await db.Houses.ToListAsync();
        return houses;
    }

    public async Task<Core.Models.House> GetByIdAsync(int id)
    {
        var house = await db.Houses.FirstOrDefaultAsync(h => h.Id == id);
        return house;
    }

    public async Task<int> AddAsync(Core.Models.House house)
    {
        await db.Houses.AddAsync(house);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> UpdateAsync(Core.Models.House house)
    {
        db.Houses.Update(house);
        int res = await db.SaveChangesAsync();

        return res;
    }


    public async Task<int> DeleteAsync(int id)
    {
        var house = await db.Houses.FirstOrDefaultAsync(h => h.Id == id);
        db.Houses.Remove(house);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<House>> GetByPage(int pageSize, int pageNumber)
    {
        List<Core.Models.House> houses = await db.Houses
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return houses;
    }

    public async Task<List<House>> GetFullByPage(int pageSize, int pageNumber)
    {
        List<Core.Models.House> houses = await db.Houses
            .Include(f => f.LandLord)
            .ThenInclude(ll => ll.AdditionalInfo)
            .Include(f => f.Contracts)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return houses;
    }

    public async Task<List<House>> GetByFilter(string city, decimal averageCost)
    {
        var q = db.Houses.AsNoTracking();

        if (!string.IsNullOrEmpty(city)) q = q.Where(h => h.City == city);

        if (averageCost > 0) q = q.Where(h => h.CostPerDay > averageCost);

        return await q.ToListAsync();
    }
}