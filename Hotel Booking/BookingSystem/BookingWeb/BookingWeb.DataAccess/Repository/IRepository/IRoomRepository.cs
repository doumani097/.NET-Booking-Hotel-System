using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IRoomRepository
    {
        Task<IList<Room>> GetRooms(string url);
        Task<IList<Room>> GetRooms(string url, int branchId);
        Task<Room> GetRoom(string url, int id);
        Task<bool> CreateRoom(string url, Room room);
        Task<bool> UpdateRoom(string url, Room room);
        Task<bool> DeleteRoom(string url, Room room);
    }
}
