using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class LesseeService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _lesseeChacheKey = "Lessee_All";

    public async Task<IEnumerable<Lessee>> GetLessees()
    {
        IEnumerable <Lessee> lessees = null;
        if(!cache.TryGetValue(_lesseeChacheKey, out lessees))
        {
            lessees = await db.Lessees.ToListAsync();
            if (lessees != null)
            {
                cache.Set(_lesseeChacheKey, lessees, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }
        return lessees;
    }

    public async Task<Lessee> GetLessee(Int32 id)
    {
        Lessee lessee = null;
        if(!cache.TryGetValue("Lessee" + id, out lessee))
        {
            lessee = await db.Lessees.FirstOrDefaultAsync(l => l.Lid == id);
            if (lessee != null)
            {
                cache.Set("Lessee" + lessee.Lid, lessee,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return lessee;
    }

    public async Task AddLessee(Lessee lessee)
    {
        db.Lessees.Add(lessee);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0) 
        {
            cache.Set("Lessee" + lessee.Lid, lessee, new MemoryCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration) 
            });
        }
    }
    
    public async Task<Int32> UpdateLessee(Lessee lessee)
    {
        if (!db.Lessees.Any(l => l.Lid == lessee.Lid))
        {
            return 0;
        }
        
        db.Lessees.Update(lessee);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("Lessee" + lessee.Lid, lessee, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteLessee(Int32 id)
    {
        Lessee lessee = null;
        lessee = await db.Lessees.FirstOrDefaultAsync(l => l.Lid == id);
        if (lessee == null)
        {
            return 0;
        }
        db.Lessees.Remove(lessee);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}