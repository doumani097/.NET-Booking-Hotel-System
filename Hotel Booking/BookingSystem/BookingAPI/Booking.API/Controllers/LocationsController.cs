using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        [Route("GetAllLocations")]
        public IActionResult GetAllLocations()
        {
            var locations = _locationRepository.GetLocations();
            return Ok(locations);
        }
        
        [HttpGet]
        [Route("GetAllLocations/{hotelId}")]
        public IActionResult GetAllLocations(int hotelId)
        {
            var locations = _locationRepository.GetLocations(hotelId);
            return Ok(locations);
        }
        
        [HttpGet]
        [Route("GetLocation/{id}")]
        public IActionResult GetLocation(int id)
        {
            var location = _locationRepository.GetLocation(id);
            if(location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }
        
        [HttpPost]
        [Route("CreateLocation")]
        public IActionResult CreateLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.CreateLocation(location);
                return Ok("Created Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateLocation")]
        public IActionResult UpdateLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.UpdateLocation(location);
                return Ok("Updated Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteLocation")]
        public IActionResult DeleteLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.DeleteLocation(location);
                return Ok("Deleted Successfully...");
            }
            return BadRequest();
        }
    }
}
