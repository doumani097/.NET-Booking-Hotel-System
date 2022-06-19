using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface ILocationRepository
    {
        IList<Location> GetLocations();
        IList<Location> GetLocations(int hotelId);
        Location GetLocation(int id);
        void CreateLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
    }
}