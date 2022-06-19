using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<ActionResult> Index()
        {
            var Reservations = await _reservationRepository.GetReservations(SD.ReservationAPIPath + "GetAllReservations");
            return View(Reservations);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id != 0)
            {
                var Reservation = await _reservationRepository.GetReservation(SD.ReservationAPIPath + "GetReservation/", id);
                if(await _reservationRepository.DeleteReservation(SD.ReservationAPIPath + "DeleteReservation", Reservation))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
