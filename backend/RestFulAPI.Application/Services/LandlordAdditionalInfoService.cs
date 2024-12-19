using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class LandlordAdditionalInfoService(ILandlordAdditionalInfo repo) : ILandlordAdditionalInfoService 
{
    public async Task<List<LandlordAdditionalInfo>> GetAdditionalInfosAsync()
    {
        List<LandlordAdditionalInfo> additionalInfos = await repo.GetAdditionalInfosAsync();
        
        return additionalInfos;
    }

    public async Task<LandlordAdditionalInfo> GetAdditionalInfoByIdAsync(int id)
    {
        LandlordAdditionalInfo additionalInfo = await repo.GetAdditionalInfoByIdAsync(id);
        
        return additionalInfo;
    }

    public async Task<int> AddAdditionalInfoAsync(LandlordAdditionalInfo additionalInfos)
    {
        int res = await repo.AddAdditionalInfoAsync(additionalInfos);

        return res;
    }

    public async Task<int> UpdateAdditionalInfoAsync(LandlordAdditionalInfo additionalInfos)
    {
        int res = await repo.UpdateAdditionalInfoAsync(additionalInfos);

        return res;
    }

    public async Task<int> DeleteAdditionalInfoAsync(int id)
    {
        int res  = await repo.DeleteAdditionalInfoAsync(id);
        
        return res;
    }

    public async Task<List<LandlordAdditionalInfo>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<LandlordAdditionalInfo> additionalInfos = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return additionalInfos;
    }

    public async Task<List<LandlordAdditionalInfo>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<LandlordAdditionalInfo> additionalInfos = await repo.GetFullByPageAsync(pageNumber, pageSize);
        
        return additionalInfos;
    }

    public async Task<List<LandlordAdditionalInfo>> GetByFilter(string telephone, decimal averageMark)
    {
        List<LandlordAdditionalInfo> additionalInfos = await repo.GetByFilter(telephone, averageMark);
            
        return additionalInfos;
    }
}