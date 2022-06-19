using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<ActionResult> Index()
        {
            var Bookings = await _bookingRepository.GetBookings(SD.BookingAPIPath + "GetAllBookings");
            return View(Bookings);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id != 0)
            {
                var Booking = await _bookingRepository.GetBooking(SD.BookingAPIPath + "GetBookings/", id);
                Booking.Reservations = null;
                if(await _bookingRepository.DeleteBooking(SD.BookingAPIPath + "DeleteBookings", Booking))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Details(int id)
        {
            if(id != 0)
            {
                var Booking = await _bookingRepository.GetBooking(SD.BookingAPIPath + "GetBookings/", id);
                return View(Booking);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
