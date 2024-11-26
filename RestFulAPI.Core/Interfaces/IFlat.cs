using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface IFlat
{
    public Task<List<Flat>> GetAllFlatsAsync();
    public Task<List<Flat>> GetAllFlatsFullAsync();
    public Task<Flat> GetFlatAsync(int id);
    public Task<int> AddFlatAsync(Flat flat);
    public Task<int> UpdateFlatAsync(Flat flat);
    public Task<int> DeleteFlatAsync(int id);
    public Task<List<Flat>> GetByPage(int pageSize, int pageNumber);
    public Task<List<Flat>> GetFullByPage(int pageSize, int pageNumber);
    public Task<List<Flat>> GetByFilter(string city, decimal averageCost);
}