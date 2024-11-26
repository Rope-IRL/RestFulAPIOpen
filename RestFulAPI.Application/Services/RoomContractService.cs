using RestFulAPI.Application.Interfaces;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;

namespace RestFulAPI.Application.Services;

public class RoomContractService(IRoomContract repo) : IRoomContractService
{
    public async Task<List<RoomContract>> GetAllRoomContractsAsync()
    {
        List<RoomContract> roomContracts = await repo.GetAllRoomContractsAsync();
        
        return roomContracts;
    }

    public async Task<RoomContract> GetRoomContractByIdAsync(int id)
    {
        RoomContract roomContract = await repo.GetRoomContractByIdAsync(id);
        
        return roomContract;
    }

    public async Task<int> AddRoomContractAsync(RoomContract roomContract)
    {
        int result = await repo.AddRoomContractAsync(roomContract);
        
        return result;
    }

    public async Task<int> UpdateRoomContractAsync(RoomContract roomContract)
    {
        int result = await repo.UpdateRoomContractAsync(roomContract);
        
        return result;
    }

    public async Task<int> DeleteRoomContractAsync(int id)
    {
        int res = await repo.DeleteRoomContractAsync(id);
        
        return res;
    }

    public async Task<List<RoomContract>> GetByPageAsync(int pageNumber, int pageSize)
    {
        List<RoomContract> roomContracts = await repo.GetByPageAsync(pageNumber, pageSize);
        
        return roomContracts;
    }

    public async Task<List<RoomContract>> GetFullByPageAsync(int pageNumber, int pageSize)
    {
        List<RoomContract> roomContracts = await repo.GetFullByPageAsync(pageNumber, pageSize);
        
        return roomContracts;
    }

    public async Task<List<RoomContract>> GetByFilter(DateOnly startDate, DateOnly endDate)
    {
        List<RoomContract> roomContracts = await repo.GetByFilter(startDate, endDate);
        
        return roomContracts;
    }
}