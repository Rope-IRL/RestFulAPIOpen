using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class RoomsContractService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _roomsContractCacheKey = "RoomsContract";

    public async Task<IEnumerable<RoomsContract>> GetRoomsContractsAsync()
    {
        IEnumerable<RoomsContract> roomsContracts = null;
        if (!cache.TryGetValue(_roomsContractCacheKey, out roomsContracts))
        {
            roomsContracts = await db.RoomsContracts.Take(20).ToListAsync();
            if (roomsContracts != null)
            {
                cache.Set(_roomsContractCacheKey, roomsContracts, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }

        }
        return roomsContracts;
    }

    public async Task<RoomsContract> GetRoomsContract(Int32 id)
    {
        RoomsContract roomsContracts = null;
        if (!cache.TryGetValue("RoomsContract" + id, out roomsContracts))
        {
            roomsContracts = await db.RoomsContracts.FirstOrDefaultAsync(l => l.Id == id);
            if (roomsContracts != null)
            {
                cache.Set("RoomsContract" + roomsContracts.Id, roomsContracts,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return roomsContracts;
    }

    public async Task AddRoomsContract(RoomsContract roomsContracts)
    {
        db.RoomsContracts.Add(roomsContracts);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("RoomsContract" + roomsContracts.Id, roomsContracts, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateRoomsContract(RoomsContract roomsContracts)
    {
        if (!db.RoomsContracts.Any(l => l.Id == roomsContracts.Id))
        {
            return 0;
        }
        
        db.RoomsContracts.Update(roomsContracts);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("RoomsContract" + roomsContracts.Id, roomsContracts, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteRoomsContract(Int32 id)
    {
        RoomsContract roomsContracts = null;
        roomsContracts = await db.RoomsContracts.FirstOrDefaultAsync(l => l.Id == id);
        if (roomsContracts == null)
        {
            return 0;
        }
        db.RoomsContracts.Remove(roomsContracts);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}