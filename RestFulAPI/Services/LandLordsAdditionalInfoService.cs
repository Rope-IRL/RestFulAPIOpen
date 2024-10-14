using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class LandLordsAdditionalInfoService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _landLordsChacheKey = "LandLordsAdditionalInfo_All";

    public async Task<IEnumerable<LandLordsAdditionalInfo>> GetLandLordsAdditionalInfo()
    {
        IEnumerable<LandLordsAdditionalInfo> landLordsAdditional = null;
        if (!cache.TryGetValue(_landLordsChacheKey, out landLordsAdditional))
        {
            landLordsAdditional = await db.LandLordsAdditionalInfos.ToListAsync();
            if (landLordsAdditional != null)
            {
                cache.Set(_landLordsChacheKey, landLordsAdditional, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }
        return landLordsAdditional;
    }

    public async Task<LandLordsAdditionalInfo> GetLandLordAdditionalInfo(Int32 id)
    {
        LandLordsAdditionalInfo landLordsAdditional = null;
        if (!cache.TryGetValue("LandLordsAdditionalInfo" + id, out landLordsAdditional))
        {
            landLordsAdditional = await db.LandLordsAdditionalInfos.FirstOrDefaultAsync(l => l.Id == id);
            if (landLordsAdditional != null)
            {
                cache.Set("LandLordsAdditionalInfo" + landLordsAdditional.Id, landLordsAdditional,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return landLordsAdditional;
    }

    public async Task AddLandLordsAdditionalInfo(LandLordsAdditionalInfo landLordsAdditional)
    {
        db.LandLordsAdditionalInfos.Add(landLordsAdditional);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("LandLordsAdditionalInfo" + landLordsAdditional.Id, landLordsAdditional, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateLandLordsAdditionalInfo(LandLordsAdditionalInfo landLordsAdditional)
    {
        if (!db.LandLordsAdditionalInfos.Any(l => l.Id == landLordsAdditional.Id))
        {
            return 0;
        }
        
        db.LandLordsAdditionalInfos.Update(landLordsAdditional);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("LandLordsAdditionalInfo" + landLordsAdditional.Id, landLordsAdditional, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteLandLordAdditionalInfo(Int32 id)
    {
        LandLordsAdditionalInfo landLordsAdditional = null;
        landLordsAdditional = await db.LandLordsAdditionalInfos.FirstOrDefaultAsync(l => l.Id == id);
        if (landLordsAdditional == null)
        {
            return 0;
        }
        db.LandLordsAdditionalInfos.Remove(landLordsAdditional);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}