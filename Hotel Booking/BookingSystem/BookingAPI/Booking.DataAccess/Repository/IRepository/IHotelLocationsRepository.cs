using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IHotelLocationsRepository
    {
        IList<HotelLocation> GetHotelLocations();
        HotelLocation GetHotelLocation(int id);
        void CreateHotelLocation(HotelLocation hotelLocation);
        void UpdateHotelLocation(HotelLocation hotelLocation);
        void DeleteHotelLocation(HotelLocation hotelLocation);
    }
}