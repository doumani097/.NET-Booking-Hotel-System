using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class HotelLocationsRepository : IHotelLocationsRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelLocationsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateHotelLocation(HotelLocation hotelLocation)
        {
            hotelLocation.CreatedAt = System.DateTime.Now;
            _db.HotelLocations.Add(hotelLocation);
            _db.SaveChanges();
        }

        public void DeleteHotelLocation(HotelLocation hotelLocation)
        {
            _db.HotelLocations.Remove(hotelLocation);
            _db.SaveChanges();
        }

        public HotelLocation GetHotelLocation(int id)
        {
            return _db.HotelLocations.Find(id);
        }

        public IList<HotelLocation> GetHotelLocations()
        {
            return _db.HotelLocations.Include(hl => hl.Location).Include(hl => hl.Hotel).ToList();
        }

        public void UpdateHotelLocation(HotelLocation hotelLocation)
        {
            _db.HotelLocations.Update(hotelLocation);
            _db.SaveChanges();
        }
    }
}
