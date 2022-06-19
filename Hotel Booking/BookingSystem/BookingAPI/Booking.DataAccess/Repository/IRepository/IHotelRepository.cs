using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IHotelRepository
    {
        IList<Hotel> GetHotels();
        Hotel GetHotel(int id);
        bool CreateHotel(Hotel hotel);
        bool UpdateHotel(Hotel hotel);
        bool DeleteHotel(Hotel hotel);
    }
}