using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IBookingRepository
    {
        Task<IList<Bookings>> GetBookings(string url);
        Task<Bookings> GetBooking(string url, int id);
        Task<int> CreateBooking(string url, Bookings bookings);
        Task<bool> UpdateBooking(string url, Bookings bookings);
        Task<bool> DeleteBooking(string url, Bookings bookings);
    }
}
