using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Interfaces;

public interface IHotelService
{
    public Task<List<Hotel>> GetAllHotels();

    public Task<Hotel> GetHotelById(int id);

    public Task<int> AddHotel(Hotel hotel);

    public Task<int> UpdateHotel(Hotel hotel);

    public Task<int> DeleteHotel(int id);

    public Task<List<Hotel>> GetByPageAsync(int pageNumber, int pageSize);

    public Task<List<Hotel>> GetFullByPageAsync(int pageNumber, int pageSize);

    public Task<List<Hotel>> GetByFilter(string city, decimal averageMark);

    public Task<List<Hotel>> GetByLandlord(int llId);
}
