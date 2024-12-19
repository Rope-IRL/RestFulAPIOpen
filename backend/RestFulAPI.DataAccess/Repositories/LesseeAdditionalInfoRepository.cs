using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class LesseeAdditionalInfoRepository(RentDbContext db) : ILesseeAdditionalInfo
{
    public async Task<int> AddLesseeAdditionalInfo(Core.Models.LesseeAdditionalInfo lesseeAdditionalInfo)
    {
        db.LesseeAdditionalInfos.AddAsync(lesseeAdditionalInfo);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteLesseeAdditionalInfo(int id)
    {
        var info = await db.LesseeAdditionalInfos.FirstOrDefaultAsync(l => l.Id == id);
        db.LesseeAdditionalInfos.Remove(info);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<LesseeAdditionalInfo>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<LesseeAdditionalInfo> lesseeAdditionalInfos = await db.LesseeAdditionalInfos
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
        
        return lesseeAdditionalInfos;
    }

    public async Task<List<LesseeAdditionalInfo>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<LesseeAdditionalInfo> lesseeAdditionalInfos = await db.LesseeAdditionalInfos
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
        
        return lesseeAdditionalInfos;
    }

    public async Task<List<LesseeAdditionalInfo>> GetByFilter(string telephone, decimal averageMark)
    {
        var q = db.LesseeAdditionalInfos
            .AsNoTracking();

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

    public async Task<List<Core.Models.LesseeAdditionalInfo>> GetAllLesseeAdditionalInfos()
    {
        var addInfos = await db.LesseeAdditionalInfos.ToListAsync();

        return addInfos;
    }

    public async Task<Core.Models.LesseeAdditionalInfo> GetLesseeAdditionalInfoById(int id)
    {
        LesseeAdditionalInfo info = await db.LesseeAdditionalInfos.FirstOrDefaultAsync(l => l.LesseeId == id);

        return info;
    }

    public async Task<int> UpdateLesseeAdditionalInfo(Core.Models.LesseeAdditionalInfo lesseeAdditionalInfo)
    {
        db.LesseeAdditionalInfos.Update(lesseeAdditionalInfo);
        int res = await db.SaveChangesAsync();
        
        return res;
    }
}