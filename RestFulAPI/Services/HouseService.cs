using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class HouseService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _houseChacheKey = "Houses";

    public async Task<IEnumerable<House>> GetHouses()
    {
        IEnumerable<House> houses = null;
        if (!cache.TryGetValue(_houseChacheKey, out houses))
        {
            houses = await db.Houses.ToListAsync();
            if (houses != null)
            {
                cache.Set(_houseChacheKey, houses, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }
        return houses;
    }

    public async Task<House> GetHouse(Int32 id)
    {
        House house = null;
        if (!cache.TryGetValue("House" + id, out house))
        {
            house = await db.Houses.FirstOrDefaultAsync(l => l.Pid == id);
            if (house != null)
            {
                cache.Set("House" + house.Pid, house,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return house;
    }

    public async Task AddHouse(House house)
    {
        db.Houses.Add(house);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("House" + house.Pid, house, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateHouse(House house)
    {
        if (!db.Houses.Any(l => l.Pid == house.Pid))
        {
            return 0;
        }
        
        db.Houses.Update(house);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("House" + house.Pid, house, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteHouse(Int32 id)
    {
        House house = null;
        house = await db.Houses.FirstOrDefaultAsync(l => l.Pid == id);
        if (house == null)
        {
            return 0;
        }
        db.Houses.Remove(house);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}