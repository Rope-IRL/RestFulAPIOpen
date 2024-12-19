using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface ILandlordAdditionalInfo
{
    public Task<List<LandlordAdditionalInfo>> GetAdditionalInfosAsync();
    
    public Task<LandlordAdditionalInfo> GetAdditionalInfoByIdAsync(int id);
    
    public Task<int> AddAdditionalInfoAsync(LandlordAdditionalInfo additionalInfos);
    
    public Task<int> UpdateAdditionalInfoAsync(LandlordAdditionalInfo additionalInfos);
    
    public Task<int> DeleteAdditionalInfoAsync(int id);
    
    public Task<List<LandlordAdditionalInfo>> GetByPageAsync(int pageNumber, int pageSize);
    
    public Task<List<LandlordAdditionalInfo>> GetFullByPageAsync(int pageNumber, int pageSize);

    public Task<List<LandlordAdditionalInfo>> GetByFilter(string telephone, decimal averageMark);
}