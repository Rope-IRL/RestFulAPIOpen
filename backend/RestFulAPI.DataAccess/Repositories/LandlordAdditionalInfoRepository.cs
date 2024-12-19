using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class LandlordAdditionalInfoRepository(RentDbContext db) : ILandlordAdditionalInfo
{
    public async Task<int> AddAdditionalInfoAsync(Core.Models.LandlordAdditionalInfo landlordAdditionalInfo)
    {
        await db.AddAsync(landlordAdditionalInfo);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteAdditionalInfoAsync(int id)
    {
        var info = await db.LandlordAdditionalInfos.FirstOrDefaultAsync(l => l.Id == id);
        db.LandlordAdditionalInfos.Remove(info);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Core.Models.LandlordAdditionalInfo>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<LandlordAdditionalInfo> landlordAdditionalInfos = await db.LandlordAdditionalInfos
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return landlordAdditionalInfos;
    }

    public async Task<List<Core.Models.LandlordAdditionalInfo>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<LandlordAdditionalInfo> landlordAdditionalInfos = await db.LandlordAdditionalInfos
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return landlordAdditionalInfos;
    }

    public async Task<List<Core.Models.LandlordAdditionalInfo>> GetByFilter(string telephone, decimal averageMark)
    {
        var q = db.LandlordAdditionalInfos.AsNoTracking();

        if (!string.IsNullOrEmpty(telephone))
        {
            q = q.Where(l => l.Telephone.Contains(telephone));
        }

        if (averageMark > 0)
        {
            q = q.Where(l => l.AverageMark >= averageMark);
        }

        return await q.ToListAsync();
    }

    public async Task<List<Core.Models.LandlordAdditionalInfo>> GetAdditionalInfosAsync()
    {
        var addInfos = await db.LandlordAdditionalInfos.ToListAsync();
        return addInfos;
    }

    public async Task<Core.Models.LandlordAdditionalInfo> GetAdditionalInfoByIdAsync(int id)
    {
        var info = await db.LandlordAdditionalInfos.FirstOrDefaultAsync(l => l.LandlordId == id);
        return info;
    }

    public async Task<int> UpdateAdditionalInfoAsync(Core.Models.LandlordAdditionalInfo landlordAdditionalInfo)
    {
        db.LandlordAdditionalInfos.Update(landlordAdditionalInfo);
        int res = await db.SaveChangesAsync();
        return res;
    }
}
