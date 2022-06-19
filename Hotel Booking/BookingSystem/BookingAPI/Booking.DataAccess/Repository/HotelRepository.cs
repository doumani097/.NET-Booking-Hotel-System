using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateHotel(Hotel hotel)
        {
            hotel.CreatedAt = System.DateTime.Now;
            _db.Hotels.Add(hotel);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteHotel(Hotel hotel)
        {
            if(CheckAvailablity(hotel.Id))
            {
                _db.Hotels.Remove(hotel);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Hotel GetHotel(int id)
        {
            if (CheckAvailablity(id))
            {
                return _db.Hotels.Find(id);
            }
            return null;
        }

        public IList<Hotel> GetHotels()
        {
            return _db.Hotels.ToList();
        }

        public bool UpdateHotel(Hotel hotel)
        {
            if (CheckAvailablity(hotel.Id))
            {
                _db.Hotels.Update(hotel);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckAvailablity(int id)
        {
            if(_db.Hotels.Any(h => h.Id == id))
            {
                return true;
            }
            return false;
        }
    }
}
