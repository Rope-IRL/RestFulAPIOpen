using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class HouseContractService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _housesContractCacheKey = "HousesContract";

    public async Task<IEnumerable<HousesContract>> GetHousesContractsAsync()
    {
        IEnumerable<HousesContract> housesContracts = null;
        if (!cache.TryGetValue(_housesContractCacheKey, out housesContracts))
        {
            housesContracts = await db.HousesContracts.Take(20).ToListAsync();
            if (housesContracts != null)
            {
                cache.Set(_housesContractCacheKey, housesContracts, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }

        }
        return housesContracts;
    }

    public async Task<HousesContract> GetHousesContract(Int32 id)
    {
        HousesContract housesContract = null;
        if (!cache.TryGetValue("HousesContract" + id, out housesContract))
        {
            housesContract = await db.HousesContracts.FirstOrDefaultAsync(l => l.Id == id);
            if (housesContract != null)
            {
                cache.Set("HousesContract" + housesContract.Id, housesContract,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return housesContract;
    }

    public async Task AddHousesContract(HousesContract housesContract)
    {
        db.HousesContracts.Add(housesContract);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("HousesContract" + housesContract.Id, housesContract, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateHousesContract(HousesContract housesContract)
    {
        if (!db.FlatsContracts.Any(l => l.Id == housesContract.Id))
        {
            return 0;
        }
        
        db.HousesContracts.Update(housesContract);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("HousesContract" + housesContract.Id, housesContract, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteHousesContract(Int32 id)
    {
        HousesContract housesContract = null;
        housesContract = await db.HousesContracts.FirstOrDefaultAsync(l => l.Id == id);
        if (housesContract == null)
        {
            return 0;
        }
        db.HousesContracts.Remove(housesContract);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}