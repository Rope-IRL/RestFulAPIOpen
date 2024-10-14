using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class HotelService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private String _hotelsChacheKey = "Hotels";

    public async Task<IEnumerable<Hotel>> GetHotels()
    {
        IEnumerable<Hotel> hotels = null;
        if (!cache.TryGetValue(_hotelsChacheKey, out hotels))
        {
            hotels = await db.Hotels.ToListAsync();
            if (hotels != null)
            {
                cache.Set(_hotelsChacheKey, hotels, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }
        return hotels;
    }

    public async Task<Hotel> GetHotel(Int32 id)
    {
        Hotel hotel = null;
        if (!cache.TryGetValue( "Hotel" + id, out hotel))
        {
            hotel = await db.Hotels.FirstOrDefaultAsync(l => l.Hid == id);
            if (hotel != null)
            {
                cache.Set("Hotel" + hotel.Hid, hotel,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return hotel;
    }

    public async Task AddHotel(Hotel hotel)
    {
        db.Hotels.Add(hotel);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("Hotel" + hotel.Hid, hotel, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateHotel(Hotel hotel)
    {
        if (!db.Hotels.Any(l => l.Hid == hotel.Hid))
        {
            return 0;
        }
        
        db.Hotels.Update(hotel);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("Hotel" + hotel.Hid, hotel, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteHotel(Int32 id)
    {
        Hotel hotel = null;
        hotel = await db.Hotels.FirstOrDefaultAsync(l => l.Hid == id);
        if (hotel == null)
        {
            return 0;
        }
        db.Hotels.Remove(hotel);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}