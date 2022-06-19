using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateLocation(Location location)
        {
            location.CreatedAt = System.DateTime.Now;
            _db.Locations.Add(location);
            _db.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            _db.Locations.Remove(location);
            _db.SaveChanges();
        }

        public Location GetLocation(int id)
        {
            return _db.Locations.Find(id);
        }

        public IList<Location> GetLocations()
        {
            return _db.Locations.ToList();
        }
        
        public IList<Location> GetLocations(int hotelId)
        {
            return _db.Locations.ToList();
        }

        public void UpdateLocation(Location location)
        {
            _db.Locations.Update(location);
            _db.SaveChanges();
        }
    }
}
