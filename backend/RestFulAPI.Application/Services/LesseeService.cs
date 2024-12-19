using RestFulAPI.Application.DTOs;
using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class LesseeService(ILessee repo) : ILesseeService
{
    public async Task<List<Lessee>> GetAllLessees()
    {
        List<Lessee> lessees = await repo.GetAllLessees();
        
        return lessees;
    }

    public async Task<Lessee> GetLessee(int id)
    {
        Lessee lessee = await repo.GetLessee(id);
       
        return lessee;
    }

    public async Task<int> AddLessee(Lessee lessee)
    {
        int res = await repo.AddLessee(lessee);
        
        return res;
    }

    public async Task<int> UpdateLessee(Lessee lessee)
    {
        int res = await repo.UpdateLessee(lessee);
        
        return res;
    }

    public async Task<int> DeleteLessee(int id)
    {
        int res = await repo.DeleteLessee(id);
        
        return res;
    }

    public async Task<List<Lessee>> GetByPage(int pageNumber, int pageSize)
    {
        List<Lessee> lessees = await repo.GetByPage(pageNumber, pageSize);
        
        return lessees;
    }

    public async Task<List<Lessee>> GetFullByPage(int pageNumber, int pageSize)
    {
        List<Lessee> lessees = await repo.GetFullByPage(pageNumber, pageSize);
        
        return lessees;
    }

    public async Task<List<Lessee>> GetByFilter(string email)
    {
        List<Lessee> lessees = await repo.GetByFilter(email);
        
        return lessees;
    }

    public async Task<LesseeDTO> GetToken(LesseeDTO lesseeDTO)
    {
        Lessee lessee = await repo.SelectLesseeByCredentials(lesseeDTO.Login, lesseeDTO.Password);

        lesseeDTO.Id = lessee.Id;

        if(lessee.AdditionalInfo != null)
        {
            lesseeDTO.Name = lessee.AdditionalInfo.Name;
        }

        else
        {
            lesseeDTO.Name = lesseeDTO.Email;
        }

        string token =null;

        if(lessee == null)
        {
            return null;
        }

        token = await GiveToken.Token(lesseeDTO);
        lesseeDTO.SetToken(token);

        return lesseeDTO;
    }
}