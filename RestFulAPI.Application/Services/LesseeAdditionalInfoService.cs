using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class LesseeAdditionalInfoService(ILesseeAdditionalInfo repo) : ILesseeAdditionalInfoService
{
    public async Task<List<LesseeAdditionalInfo>> GetAllLesseeAdditionalInfos()
    {
        List<LesseeAdditionalInfo> additionalInfos = await repo.GetAllLesseeAdditionalInfos();
        
        return additionalInfos;
    }

    public async Task<LesseeAdditionalInfo> GetLesseeAdditionalInfoById(int id)
    {
        LesseeAdditionalInfo additionalInfo = await repo.GetLesseeAdditionalInfoById(id);
        
        return additionalInfo;
    }

    public async Task<int> AddLesseeAdditionalInfo(LesseeAdditionalInfo lesseeAdditionalInfo)
    {
        int res = await repo.AddLesseeAdditionalInfo(lesseeAdditionalInfo);
        
        return res;
    }

    public async Task<int> UpdateLesseeAdditionalInfo(LesseeAdditionalInfo lesseeAdditionalInfo)
    {
        int res = await repo.UpdateLesseeAdditionalInfo(lesseeAdditionalInfo);
        
        return res;
    }

    public async Task<int> DeleteLesseeAdditionalInfo(int id)
    {
        int res = await repo.DeleteLesseeAdditionalInfo(id);
        
        return res;
    }

    public async Task<List<LesseeAdditionalInfo>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<LesseeAdditionalInfo> additionalInfos = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return additionalInfos;
    }

    public async Task<List<LesseeAdditionalInfo>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<LesseeAdditionalInfo> additionalInfos = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return additionalInfos;
    }

    public async Task<List<LesseeAdditionalInfo>> GetByFilter(string telephone, decimal averageMark)
    {
        List<LesseeAdditionalInfo> additionalInfos = await repo.GetByFilter(telephone, averageMark);
        
        return additionalInfos;
    }
}