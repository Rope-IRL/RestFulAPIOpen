using System.Globalization;
using RestFulAPI.Application.DTOs;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class LandlordService(ILandlord repo) : ILandlordService
{
    public async Task<List<Landlord>> GetAllAsync()
    {
        List<Landlord> landlords = await repo.GetAllAsync();
        
        return landlords;
    }

    public async Task<Landlord> GetByIdAsync(int id)
    {
        Landlord landlord = await repo.GetByIdAsync(id);
        
        return landlord;
    }

    public async Task<int> AddAsync(Landlord landlord)
    {
        int res = await repo.AddAsync(landlord);
       
        return res;
    }

    public async Task<int> UpdateAsync(Landlord landlord)
    {
        int res = await repo.UpdateAsync(landlord);
        
        return res;
    }

    public async Task<int> DeleteAsync(int id)
    {
        int res = await repo.DeleteAsync(id);
        
        return res;
    }

    public async Task<List<Landlord>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<Landlord> landlords = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return landlords;
    }

    public async Task<List<Landlord>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<Landlord> landlords = await repo.GetFullByPageAsync(pageNumber, pageSize);
        
        return landlords;
    }

    public async Task<List<Landlord>> GetByFilter(string email)
    {
        List<Landlord> landlords = await repo.GetByFilter(email);
        
        return landlords;
    }

    public async Task<LandlordDTO> GetToken(LandlordDTO landlordDto)
    {
        Landlord landlord = await repo.SelectLandlordByCredentials(landlordDto.Login, landlordDto.Password);
        landlordDto.Id = landlord.Id;
        if(landlord.AdditionalInfo != null){
            landlordDto.Name = landlord.AdditionalInfo.Name;

        }
        else{
            landlordDto.Name = landlordDto.Email;
        }

        string token = null;
        
        if (landlord == null)
        {
            return null;
        }
        
        token = await GiveToken.Token(landlordDto);
        landlordDto.SetToken(token);

        return landlordDto;

    }

}