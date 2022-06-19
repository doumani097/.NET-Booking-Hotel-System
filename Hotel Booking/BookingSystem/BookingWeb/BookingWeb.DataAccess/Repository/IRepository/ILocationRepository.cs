using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface ILocationRepository
    {
        Task<IList<Location>> GetLocations(string url);
        Task<IList<Location>> GetLocations(string url, int hotelId);
        Task<Location> GetLocation(string url, int id);
        Task<bool> CreateLocation(string url, Location location);
        Task<bool> UpdateLocation(string url, Location location);
        Task<bool> DeleteLocation(string url, Location location);
    }
}
