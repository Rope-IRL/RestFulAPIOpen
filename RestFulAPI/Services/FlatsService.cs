using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class FlatsService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _flatChacheKey = "Flats";

    public async Task<IEnumerable<Flat>> GetFlats()
    {
        IEnumerable<Flat> flats = null;
        if (!cache.TryGetValue(_flatChacheKey, out flats))
        {
            flats = await db.Flats.ToListAsync();
            if (flats != null)
            {
                cache.Set(_flatChacheKey, flats, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }
        return flats;
    }

    public async Task<Flat> GetFlat(Int32 id)
    {
        Flat flat = null;
        if (!cache.TryGetValue( "Flat" + id, out flat))
        {
            flat = await db.Flats.FirstOrDefaultAsync(l => l.Fid == id);
            if (flat != null)
            {
                cache.Set("Flat" + flat.Fid, flat,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return flat;
    }

    public async Task AddFlat(Flat flat)
    {
        db.Flats.Add(flat);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("Flat" + flat.Fid, flat, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateFlat(Flat flat)
    {
        if (!db.Flats.Any(l => l.Fid == flat.Fid))
        {
            return 0;
        }
        
        db.Flats.Update(flat);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("Flat" + flat.Fid, flat, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteFlat(Int32 id)
    {
        Flat flat = null;
        flat = await db.Flats.FirstOrDefaultAsync(l => l.Fid == id);
        if (flat == null)
        {
            return 0;
        }
        db.Flats.Remove(flat);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}