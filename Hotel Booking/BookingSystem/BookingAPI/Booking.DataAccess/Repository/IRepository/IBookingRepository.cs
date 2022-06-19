using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IBookingRepository
    {
        IList<Bookings> GetBookings();
        Bookings GetBookings(int id);
        int CreateBookings(Bookings bookings);
        bool UpdateBookings(Bookings bookings);
        bool DeleteBookings(Bookings bookings);
    }
}