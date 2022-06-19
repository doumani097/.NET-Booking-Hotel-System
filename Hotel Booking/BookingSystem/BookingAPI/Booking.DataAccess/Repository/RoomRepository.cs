using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _db;

        public RoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateRoom(Room room)
        {
            room.CreatedAt = System.DateTime.Now;
            _db.Rooms.Add(room);
            _db.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            _db.Rooms.Remove(room);
            _db.SaveChanges();
        }

        public Room GetRoom(int id)
        {
            return _db.Rooms.Include(r => r.Branch).FirstOrDefault(r => r.Id == id);
        }

        public IList<Room> GetRooms()
        {
            return _db.Rooms.Include(r => r.Branch).ToList();
        }
        
        public IList<Room> GetRooms(int branchId)
        {
            return _db.Rooms.Include(r => r.Branch).Where(b => b.BranchId == branchId).ToList();
        }

        public void UpdateRoom(Room room)
        {
            _db.Rooms.Update(room);
            _db.SaveChanges();
        }
    }
}
