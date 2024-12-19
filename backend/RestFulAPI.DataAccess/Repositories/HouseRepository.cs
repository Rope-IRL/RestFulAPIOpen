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

    public async Task<List<House>> GetByPage(int pageNumber, int pageSize)
    {
        List<Core.Models.House> houses = await db.Houses
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return houses;
    }

    public async Task<List<House>> GetFullByPage(int pageNumber, int pageSize)
    {
        List<Core.Models.House> houses = await db.Houses
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

    public async Task<List<House>> GetByLandlord(int llId)
    {
        List<House> houses = await db.Houses.Where(h => h.LlId == llId).ToListAsync();

        return houses;
    }

    public async Task<List<House>> GetByDates(DateOnly startDate, DateOnly endDate)
    {
        List<House> houses = await db.Houses
            .Where(house => !house.Contracts.Any(contract =>
                contract.EndDate >= startDate && contract.StartDate <= endDate))
            .ToListAsync();

        return houses;
    }

    public async Task<List<House>> GetByCity(string city)
    {
        List<House> houses = await db.Houses
            .Where(house => house.City == city)
            .ToListAsync();

        return houses;
    }

    public async Task<List<House>> GetByDatesAndCity(DateOnly startDate, DateOnly endDate, String city)
    {
        List<House> houses = await db.Houses
            .Where(house => house.City == city && (!house.Contracts.Any(contract =>
                contract.EndDate >= startDate && contract.StartDate <= endDate)))
            .ToListAsync();

        return houses;
    }
}
