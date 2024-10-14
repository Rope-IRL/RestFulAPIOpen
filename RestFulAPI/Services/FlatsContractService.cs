using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RestFulAPI.Services;

public class FlatsContractService(RealestaterentalContext db, IMemoryCache cache)
{
    private readonly Int32 _cacheDuration = 300;
    private readonly String _flatsContractCacheKey = "FlatsContract";

    public async Task<IEnumerable<FlatsContract>> GetFlatsContractsAsync()
    {
        IEnumerable<FlatsContract> flatsContracts = null;
        if (!cache.TryGetValue(_flatsContractCacheKey, out flatsContracts))
        {
            flatsContracts = await db.FlatsContracts.Take(20).ToListAsync();
            if (flatsContracts != null)
            {
                cache.Set(_flatsContractCacheKey, flatsContracts, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }

        }
        return flatsContracts;
    }

    public async Task<FlatsContract> GetFlatsContract(Int32 id)
    {
        FlatsContract flatsContract = null;
        if (!cache.TryGetValue("FlatsContract" + id, out flatsContract))
        {
            flatsContract = await db.FlatsContracts.FirstOrDefaultAsync(l => l.Id == id);
            if (flatsContract != null)
            {
                cache.Set("FlatsContract" + flatsContract.Id, flatsContract,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheDuration)));
            }
        }

        return flatsContract;
    }

    public async Task AddFlatsContract(FlatsContract flatsContract)
    {
        db.FlatsContracts.Add(flatsContract);
        Int32 n = await db.SaveChangesAsync();
        if (n > 0)
        {
            cache.Set("FlatsContract" + flatsContract.Id, flatsContract, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }
    }
    
    public async Task<Int32> UpdateFlatsContract(FlatsContract flatsContract)
    {
        if (!db.FlatsContracts.Any(l => l.Id == flatsContract.Id))
        {
            return 0;
        }
        
        db.FlatsContracts.Update(flatsContract);
        Int32 n = await db.SaveChangesAsync();
        
        if (n > 0)
        {
            cache.Set("FlatsContract" + flatsContract.Id, flatsContract, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheDuration)
            });
        }

        return n;
    }
    
    public async Task<Int32> DeleteFlatsContract(Int32 id)
    {
        FlatsContract flatsContract = null;
        flatsContract = await db.FlatsContracts.FirstOrDefaultAsync(l => l.Id == id);
        if (flatsContract == null)
        {
            return 0;
        }
        db.FlatsContracts.Remove(flatsContract);
        Int32 n = await db.SaveChangesAsync();
        return n;
    }
}
