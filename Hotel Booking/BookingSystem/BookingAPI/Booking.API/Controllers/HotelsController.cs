using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        [Route("GetAllHotels")]
        public IActionResult GetAllHotels()
        {
            var hotels = _hotelRepository.GetHotels();
            return Ok(hotels);
        }
        
        [HttpGet]
        [Route("GetHotel/{id}")]
        public IActionResult GetHotel(int id)
        {
            var hotel = _hotelRepository.GetHotel(id);
            if(hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }
        
        [HttpPost]
        [Route("CreateHotel")]
        public IActionResult CreateHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (_hotelRepository.CreateHotel(hotel))
                {
                    return Ok("Created Successfully...");
                }
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateHotel")]
        public IActionResult UpdateHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (_hotelRepository.UpdateHotel(hotel))
                {
                    return Ok("Updated Successfully...");
                }
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteHotel")]
        public IActionResult DeleteHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if (_hotelRepository.DeleteHotel(hotel))
                {
                    return Ok("Deleted Successfully...");
                }
            }
            return BadRequest();
        }

    }
}