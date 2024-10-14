using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class LesseeAdditionalInfoService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _lesseeChacheKey = "LesseesAdditionalInfo_All";

    public async Task<IEnumerable<LesseesAdditionalInfo>> GetLesseesAdditionalInfo()
    {
        IEnumerable<LesseesAdditionalInfo> lessees = null;
        if (!cache.TryGetValue(_lesseeChacheKey, out lessees))
        {
            lessees = await db.LesseesAdditionalInfos.ToListAsync();
            if (lessees != null)
            {
                cache.Set(_lesseeChacheKey, lessees, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }
        return lessees;
    }

    public async Task<LesseesAdditionalInfo> GetLesseeAdditionalInfo(Int32 id)
    {
        LesseesAdditionalInfo lessee = null;
        if (!cache.TryGetValue("LesseeAdditionalInfo" + id, out lessee))
        {
            lessee = await db.LesseesAdditionalInfos.FirstOrDefaultAsync(l => l.Id == id);
            if (lessee != null)
            {
                cache.Set("LesseeAdditionalInfo" + lessee.Lid, lessee,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return lessee;
    }

    public async Task AddLesseeAdditionalInfo(LesseesAdditionalInfo lessee)
    {
        db.LesseesAdditionalInfos.Add(lessee);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("LesseeAdditionalInfo" + lessee.Id, lessee, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateLesseeAdditionalInfo(LesseesAdditionalInfo lessee)
    {
        if (!db.LesseesAdditionalInfos.Any(l => l.Id == lessee.Id))
        {
            return 0;
        }
        
        db.LesseesAdditionalInfos.Update(lessee);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("LesseeAdditionalInfo" + lessee.Id, lessee, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteLesseeAdditionalInfo(Int32 id)
    {
        LesseesAdditionalInfo lessee = null;
        lessee = await db.LesseesAdditionalInfos.FirstOrDefaultAsync(l => l.Id == id);
        if (lessee == null)
        {
            return 0;
        }
        db.LesseesAdditionalInfos.Remove(lessee);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}