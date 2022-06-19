using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IRoomRepository
    {
        IList<Room> GetRooms();
        IList<Room> GetRooms(int branchId);
        Room GetRoom(int id);
        void CreateRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(Room room);
    }
}