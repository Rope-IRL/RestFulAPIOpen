using RestFulAPI.Core.Models;

namespace RestFulAPI.Core.Interfaces;

public interface ILessee
{
    public Task<List<Lessee>> GetAllLessees();
    
    public Task<Lessee> GetLessee(int id);
    
    public Task<int> AddLessee(Lessee lessee);
    
    public Task<int> UpdateLessee(Lessee lessee);
    
    public Task<int> DeleteLessee(int id);
    
    public Task<List<Lessee>> GetByPage(int pageNumber, int pageSize);
    
    public Task<List<Lessee>> GetFullByPage(int pageNumber, int pageSize);

    public Task<List<Lessee>> GetByFilter(string email);

    public Task<Lessee> SelectLesseeByCredentials(string login, string hashedpassword);
}