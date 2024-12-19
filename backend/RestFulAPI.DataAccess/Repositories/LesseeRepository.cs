using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class LesseeRepository(RentDbContext db) : ILessee
{
    public async Task<int> AddLessee(Core.Models.Lessee lessee)
    {
        await db.Lessees.AddAsync(lessee);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteLessee(int id)
    {
        var lessee = await db.Lessees.FirstOrDefaultAsync(l => l.Id == id);
        db.Lessees.Remove(lessee);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Lessee>> GetByPage(int pageNumber, int pageSize)
    {
        List<Lessee> lessees = await db.Lessees
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return lessees;
    }

    public async Task<List<Lessee>> GetFullByPage(int pageNumber, int pageSize)
    {
        List<Lessee> lessees = await db.Lessees
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return lessees;
    }

    public async Task<List<Lessee>> GetByFilter(string email)
    {
        var q = db.Lessees.AsNoTracking();
        if (!string.IsNullOrEmpty(email))
        {
            q = q.Where(l => l.Email.Contains(email));
        }

        return await q.ToListAsync();
    }

    public async Task<List<Core.Models.Lessee>> GetAllLessees()
    {
        var lessees = await db.Lessees.ToListAsync();

        return lessees;
    }

    public async Task<Core.Models.Lessee> GetLessee(int id)
    {
        var lessee = await db.Lessees.FirstOrDefaultAsync(lessee => lessee.Id == id);

        return lessee;
    }

    public async Task<int> UpdateLessee(Core.Models.Lessee lessee)
    {
        db.Lessees.Update(lessee);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<Lessee> SelectLesseeByCredentials(string login, string hashedpassword)
    {
        Lessee lessee = await db.Lessees
        .Include(l => l.AdditionalInfo)
        .FirstOrDefaultAsync(l => l.Login == login && l.HashedPassword == hashedpassword);

        return lessee;
    }
}