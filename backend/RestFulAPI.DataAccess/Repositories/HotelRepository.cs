using Microsoft.EntityFrameworkCore;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.DataAccess.Repositories;

public class HotelRepository(RentDbContext db) : IHotel
{
    public async Task<List<Core.Models.Hotel>> GetAllHotels()
    {
        var hotels = await db.Hotels.ToListAsync();

        return hotels;
    }

    public async Task<Core.Models.Hotel> GetHotelById(int id)
    {
        var hotel = await db.Hotels.FirstOrDefaultAsync(hotel => hotel.Id == id);

        return hotel;
    }

    public async Task<int> AddHotel(Core.Models.Hotel hotel)
    {
        await db.Hotels.AddAsync(hotel);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> UpdateHotel(Core.Models.Hotel hotel)
    {
        db.Hotels.Update(hotel);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<int> DeleteHotel(int id)
    {
        var hotel = await db.Hotels.FirstOrDefaultAsync(hotel => hotel.Id == id);
        db.Hotels.Remove(hotel);
        int res = await db.SaveChangesAsync();

        return res;
    }

    public async Task<List<Hotel>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<Core.Models.Hotel> hotels = await db.Hotels
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return hotels;
    }

    public async Task<List<Hotel>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<Core.Models.Hotel> hotels = await db.Hotels
            .Include(f => f.LandLord)
            .ThenInclude(ll => ll.AdditionalInfo)
            .Include(f => f.HotelRooms)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return hotels;
    }

    public async Task<List<Hotel>> GetByFilter(string city, decimal averageMark)
    {
        var q = db.Hotels.AsNoTracking();

        if (!string.IsNullOrEmpty(city)) q = q.Where(f => f.City == city);

        if (averageMark > 0) q = q.Where(flat => flat.AverageMark > averageMark);

        return await q.ToListAsync();
    }

    public async Task<List<Hotel>> GetByLandlord(int llId)
    {
        List<Hotel> hotels = await db.Hotels
        .Include(h => h.HotelRooms)
        .Where(h => h.LlId == llId).ToListAsync();

        return hotels;
    }

}
