using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelLocationsController : ControllerBase
    {
        private readonly IHotelLocationsRepository _hotelLocationsRepository;

        public HotelLocationsController(IHotelLocationsRepository HotelLocationsRepository)
        {
            _hotelLocationsRepository = HotelLocationsRepository;
        }

        [HttpGet]
        [Route("GetAllHotelLocations")]
        public IActionResult GetAllHotelLocations()
        {
            var hotelLocations = _hotelLocationsRepository.GetHotelLocations();
            return Ok(hotelLocations);
        }
        
        [HttpGet]
        [Route("GetHotelLocation/{id}")]
        public IActionResult GetHotelLocation(int id)
        {
            var HotelLocation = _hotelLocationsRepository.GetHotelLocation(id);
            if(HotelLocation == null)
            {
                return NotFound();
            }
            return Ok(HotelLocation);
        }
        
        [HttpPost]
        [Route("CreateHotelLocation")]
        public IActionResult CreateHotelLocation(HotelLocation hotelLocation)
        {
            if (ModelState.IsValid)
            {
                _hotelLocationsRepository.CreateHotelLocation(hotelLocation);
                return Ok("Created Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateHotelLocation")]
        public IActionResult UpdateHotelLocation(HotelLocation hotelLocation)
        {
            if (ModelState.IsValid)
            {
                _hotelLocationsRepository.UpdateHotelLocation(hotelLocation);
                return Ok("Updated Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteHotelLocation")]
        public IActionResult DeleteHotelLocation(HotelLocation hotelLocation)
        {
            if (ModelState.IsValid)
            {
                _hotelLocationsRepository.DeleteHotelLocation(hotelLocation);
                return Ok("Deleted Successfully...");
            }
            return BadRequest();
        }
    }
}
