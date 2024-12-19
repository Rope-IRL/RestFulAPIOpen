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

    public async Task<List<RoomContract>> GetByLandlordId(int id)
    {
        List<RoomContract> roomContracts = await repo.GetByLandlordId(id);
        return roomContracts;
    }

    public async Task<List<RoomContract>> GetByLesseeId(int id)
    {
        List<RoomContract> roomContracts = await repo.GetByLesseeId(id);

        return roomContracts;
    }

    public async Task<HashSet<int>> GetRoomContractByYearAndMonthAndRoomId(int flatId, int year, int month)
    {
        int maxDay = DateTime.DaysInMonth(year, month);
        HashSet<int> notAvailableDays = new HashSet<int>();
        HashSet<int> availableDays = new HashSet<int>();
        List<RoomContract> contracts = await repo.GetRoomContractByYearAndMonthAndRoomId(flatId, year, month);


        foreach (RoomContract contract in contracts)
        {
            if (contract.StartDate.Month < month && contract.EndDate.Month == month)
            {
                for (int i = 1; i <= contract.EndDate.Day; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
            else if (contract.StartDate.Month == month && contract.EndDate.Month == month)
            {
                for (int i = contract.StartDate.Day; i <= contract.EndDate.Day; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
            else if (contract.StartDate.Month == month && contract.EndDate.Month > month)
            {
                for (int i = contract.StartDate.Day; i <= maxDay; i++)
                {
                    notAvailableDays.Add(i);
                }
            }
        }

        for (int i = 1; i <= maxDay; i++)
        {
            if (!notAvailableDays.Contains(i))
            {
                availableDays.Add(i);
            }
        }

        return availableDays;
    }
}