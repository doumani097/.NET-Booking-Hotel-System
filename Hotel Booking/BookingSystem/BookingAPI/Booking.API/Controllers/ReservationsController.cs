using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    { 
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        [Route("GetAllReservations")]
        public IActionResult GetAllReservations()
        {
            var Reservations = _reservationRepository.GetReservations();
            return Ok(Reservations);
        }
        
        [HttpGet]
        [Route("GetReservation/{id}")]
        public IActionResult GetReservation(int id)
        {
            var reservation = _reservationRepository.GetReservation(id);
            if(reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }
        
        [HttpPost]
        [Route("CreateReservation")]
        public IActionResult CreateReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationRepository.CreateReservation(reservation);
                return Ok("Created Successfully...");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("AddBulkReservation")]
        public IActionResult AddBulkReservation(List<Reservation> reservations)
        {
            if (ModelState.IsValid)
            {
                _reservationRepository.AddBulkReservation(reservations);
                return Ok("Created Successfully...");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateReservation")]
        public IActionResult UpdateReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationRepository.UpdateReservation(reservation);
                return Ok("Updated Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteReservation")]
        public IActionResult DeleteReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationRepository.DeleteReservation(reservation);
                return Ok("Deleted Successfully...");
            }
            return BadRequest();
        }
    }
}
