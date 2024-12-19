using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class HotelService(IHotel repo) : IHotelService
{
    public async Task<List<Hotel>> GetAllHotels()
    {
        List<Hotel> hotels = await repo.GetAllHotels();

        return hotels;
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        Hotel hotel = await repo.GetHotelById(id);

        return hotel;
    }

    public async Task<int> AddHotel(Hotel hotel)
    {
        int res = await repo.AddHotel(hotel);

        return res;
    }

    public async Task<int> UpdateHotel(Hotel hotel)
    {
        int res = await repo.UpdateHotel(hotel);

        return res;
    }

    public async Task<int> DeleteHotel(int id)
    {
        int res = await repo.DeleteHotel(id);

        return res;
    }

    public async Task<List<Hotel>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<Hotel> hotels = await repo.GetByPageAsync(pageNumber, pageSize);

        return hotels;
    }

    public async Task<List<Hotel>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<Hotel> hotels = await repo.GetFullByPageAsync(pageNumber, pageSize);

        return hotels;
    }

    public async Task<List<Hotel>> GetByFilter(string city, decimal averageMark)
    {
        List<Hotel> hotels = await repo.GetByFilter(city, averageMark);

        return hotels;
    }

    public async Task<List<Hotel>> GetByLandlord(int llId)
    {
        List<Hotel> hotels = await repo.GetByLandlord(llId);

        return hotels;
    }
}
