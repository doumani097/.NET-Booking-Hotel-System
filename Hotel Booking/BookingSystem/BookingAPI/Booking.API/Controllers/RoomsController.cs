using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        [Route("GetAllRooms")]
        public IActionResult GetAllRooms()
        {
            var rooms = _roomRepository.GetRooms();
            return Ok(rooms);
        }

        [HttpGet]
        [Route("GetAllRooms/{branchId}")]
        public IActionResult GetAllRooms(int branchId)
        {
            var rooms = _roomRepository.GetRooms(branchId);
            return Ok(rooms);
        }
        
        [HttpGet]
        [Route("GetRoom/{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = _roomRepository.GetRoom(id);
            if(room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }
        
        [HttpPost]
        [Route("CreateRoom")]
        public IActionResult CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.CreateRoom(room);
                return Ok("Created Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateRoom")]
        public IActionResult UpdateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.UpdateRoom(room);
                return Ok("Updated Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteRoom")]
        public IActionResult DeleteRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.DeleteRoom(room);
                return Ok("Deleted Successfully...");
            }
            return BadRequest();
        }
    }
}
