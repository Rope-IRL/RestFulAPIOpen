using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class LandlordRepository(RentDbContext db) : ILandlord
{
    public async Task<int> AddAsync(Core.Models.Landlord landLord)
    {
        await db.Landlords.AddAsync(landLord);
        int res = await db.SaveChangesAsync();
        
        return res;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var landLord = await db.Landlords.FirstOrDefaultAsync(l => l.Id == id);
        db.Landlords.Remove(landLord);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Landlord>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<Landlord> landlords = await db.Landlords
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return landlords;
    }

    public async Task<List<Landlord>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<Landlord> landlords = await db.Landlords
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return landlords;
    }

    public async Task<List<Landlord>> GetByFilter(string email)
    {
        var q = db.Landlords.AsNoTracking();

        if (!string.IsNullOrEmpty(email))
        {
            q = q.Where(l => l.Email.Contains(email));
        }
        
        return await q.ToListAsync();
    }

    public async Task<List<Core.Models.Landlord>> GetAllAsync()
    {
        var landlords = await db.Landlords.ToListAsync();
        return landlords;
    }

    public async Task<Core.Models.Landlord> GetByIdAsync(int id)
    {
        var landLord = await db.Landlords
            .Include(l => l.AdditionalInfo)
            .FirstOrDefaultAsync(landLord => landLord.Id == id);
        return landLord;
    }

    public async Task<int> UpdateAsync(Core.Models.Landlord landLord)
    {
        db.Landlords.Update(landLord);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<Landlord> SelectLandlordByCredentials(string login, string hashedpassword)
    {
        Landlord landlord = await db.Landlords
            .Include(l => l.AdditionalInfo)
            .FirstOrDefaultAsync(l => l.Login == login && l.HashedPassword == hashedpassword);

        return landlord;
    }
}