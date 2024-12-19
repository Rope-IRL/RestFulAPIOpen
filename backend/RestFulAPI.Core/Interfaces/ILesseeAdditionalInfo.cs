using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface ILesseeAdditionalInfo
{
    public Task<List<LesseeAdditionalInfo>> GetAllLesseeAdditionalInfos();
    
    public Task<LesseeAdditionalInfo> GetLesseeAdditionalInfoById(int id);
    
    public Task<int> AddLesseeAdditionalInfo(LesseeAdditionalInfo lesseeAdditionalInfo);
    
    public Task<int> UpdateLesseeAdditionalInfo(LesseeAdditionalInfo lesseeAdditionalInfo);
    
    public Task<int> DeleteLesseeAdditionalInfo(int id);
    
    public Task<List<LesseeAdditionalInfo>> GetByPageAsync(int pageNumber, int pageSize);

    public Task<List<LesseeAdditionalInfo>> GetFullByPageAsync(int pageNumber, int pageSize);

    public Task<List<LesseeAdditionalInfo>> GetByFilter(string telephone, decimal averageMark);
}