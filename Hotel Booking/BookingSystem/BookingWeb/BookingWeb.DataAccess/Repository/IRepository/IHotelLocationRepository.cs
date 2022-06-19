using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IHotelLocationRepository
    {
        Task<IList<HotelLocation>> GetHotelLocations(string url);
        Task<HotelLocation> GetHotelLocation(string url, int id);
        Task<bool> CreateHotelLocation(string url, HotelLocation hotelLocation);
        Task<bool> UpdateHotelLocation(string url, HotelLocation hotelLocation);
        Task<bool> DeleteHotelLocation(string url, HotelLocation hotelLocation);
    }
}
