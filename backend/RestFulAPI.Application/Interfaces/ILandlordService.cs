using RestFulAPI.Application.DTOs;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces;

public interface ILandlordService
{
    public Task<List<Landlord>> GetAllAsync();

    public Task<Landlord> GetByIdAsync(int id);

    public Task<int> AddAsync(Landlord landlord);

    public Task<int> UpdateAsync(Landlord landlord);

    public Task<int> DeleteAsync(int id);

    public Task<List<Landlord>> GetByPageAsync(int pageNumber, int pageSize);

    public Task<List<Landlord>> GetFullByPageAsync(int pageNumber, int pageSize);

    public Task<List<Landlord>> GetByFilter(string email);

    public Task<LandlordDTO> GetToken(LandlordDTO landlordDto);

}
