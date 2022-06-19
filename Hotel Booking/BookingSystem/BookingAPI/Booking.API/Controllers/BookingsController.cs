using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        [Route("GetAllBookings")]
        public IActionResult GetAllBookings()
        {
            var Bookings = _bookingRepository.GetBookings();
            return Ok(Bookings);
        }
        
        [HttpGet]
        [Route("GetBookings/{id}")]
        public IActionResult GetBookings(int id)
        {
            var Bookings = _bookingRepository.GetBookings(id);
            if(Bookings == null)
            {
                return NotFound();
            }
            return Ok(Bookings);
        }
        
        [HttpPost]
        [Route("CreateBookings")]
        public IActionResult CreateBookings(Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                var bookid = _bookingRepository.CreateBookings(bookings);
                return Ok(bookid);
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateBookings")]
        public IActionResult UpdateBookings(Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                if (_bookingRepository.UpdateBookings(bookings))
                {
                    return Ok("Updated Succesfully...");
                }
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteBookings")]
        public IActionResult DeleteBookings(Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                if (_bookingRepository.DeleteBookings(bookings))
                {
                    return Ok("Deleted Succesfully...");
                }
            }
            return BadRequest();
        }

    }
}