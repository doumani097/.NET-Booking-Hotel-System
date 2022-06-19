using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _db;

        public BookingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int CreateBookings(Bookings bookings)
        {
            bookings.CreatedAt = System.DateTime.Now;
            var booking = _db.Bookings.Add(bookings);
            _db.SaveChanges();
            return booking.Entity.Id;
        }

        public bool DeleteBookings(Bookings bookings)
        {
            if(CheckAvailablity(bookings.Id))
            {
                _db.Bookings.Remove(bookings);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Bookings GetBookings(int id)
        {
            if (CheckAvailablity(id))
            {
                return _db.Bookings.Include(r => r.Reservations).ThenInclude(r => r.ContactInformation)
                .Include(r => r.Reservations).ThenInclude(r => r.Room).ThenInclude(r => r.Branch).FirstOrDefault(b => b.Id == id);
            }
            return null;
        }

        public IList<Bookings> GetBookings()
        {
            return _db.Bookings.ToList();
        }

        public bool UpdateBookings(Bookings bookings)
        {
            if (CheckAvailablity(bookings.Id))
            {
                _db.Bookings.Update(bookings);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckAvailablity(int id)
        {
            if(_db.Bookings.AsNoTracking().Any(h => h.Id == id))
            {
                return true;
            }
            return false;
        }
    }
}
