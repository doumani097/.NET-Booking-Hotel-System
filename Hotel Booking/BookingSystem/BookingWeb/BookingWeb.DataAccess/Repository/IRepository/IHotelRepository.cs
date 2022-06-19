using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IHotelRepository
    {
        Task<IList<Hotel>> GetHotels(string url);
        Task<Hotel> GetHotel(string url, int id);
        Task<bool> CreateHotel(string url, Hotel hotel);
        Task<bool> UpdateHotel(string url, Hotel hotel);
        Task<bool> DeleteHotel(string url, Hotel hotel);
    }
}
