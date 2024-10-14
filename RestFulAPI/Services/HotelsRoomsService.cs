using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class HotelsRoomsService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _hotelsRoomCacheKey = "HotelsRoom";

    public async Task<IEnumerable<HotelsRoom>> GetHotelsRoomAsync()
    {
        IEnumerable<HotelsRoom> hotelsRooms = null;
        if (!cache.TryGetValue(_hotelsRoomCacheKey, out hotelsRooms))
        {
            hotelsRooms = await db.HotelsRooms.Take(20).ToListAsync();
            if (hotelsRooms != null)
            {
                cache.Set(_hotelsRoomCacheKey, hotelsRooms, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }

        }
        return hotelsRooms;
    }

    public async Task<HotelsRoom> GetHotelsRoom(Int32 id)
    {
        HotelsRoom hotelsRoom = null;
        if (!cache.TryGetValue("HotelsRoom" + id, out hotelsRoom))
        {
            hotelsRoom = await db.HotelsRooms.FirstOrDefaultAsync(l => l.Rid == id);
            if (hotelsRoom != null)
            {
                cache.Set("HotelsRoom" + hotelsRoom.Rid, hotelsRoom,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return hotelsRoom;
    }

    public async Task AddHotelsRoom(HotelsRoom hotelsRoom)
    {
        db.HotelsRooms.Add(hotelsRoom);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("HotelsRoom" + hotelsRoom.Rid, hotelsRoom, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateHotelsRoom(HotelsRoom hotelsRoom)
    {
        if (!db.HotelsRooms.Any(l => l.Rid == hotelsRoom.Rid))
        {
            return 0;
        }
        
        db.HotelsRooms.Update(hotelsRoom);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("HotelsRoom" + hotelsRoom.Rid, hotelsRoom, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteHotelsRoom(Int32 id)
    {
        HotelsRoom hotelsRoom = null;
        hotelsRoom = await db.HotelsRooms.FirstOrDefaultAsync(l => l.Rid == id);
        if (hotelsRoom == null)
        {
            return 0;
        }
        db.HotelsRooms.Remove(hotelsRoom);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}