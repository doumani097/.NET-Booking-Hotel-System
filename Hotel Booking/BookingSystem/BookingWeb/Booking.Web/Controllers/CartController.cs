using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using BookingWeb.Models.ViewModels;
using BookingWeb.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookingRepository _bookingRepository;

        public CartController(IRoomRepository roomRepository,
            IContactInfoRepository contactInfoRepository,
            IReservationRepository reservationRepository,
            IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _contactInfoRepository = contactInfoRepository;
            _reservationRepository = reservationRepository;
            _bookingRepository = bookingRepository;
        }

        public IActionResult Index()
        {
            List<Reservation> reservations = new List<Reservation>();

            if (HttpContext.Session.Get<IEnumerable<Reservation>>("ReservationList") != null
                && HttpContext.Session.Get<IEnumerable<Reservation>>("ReservationList").Count() > 0)
            {
                //session exsits
                reservations = HttpContext.Session.Get<List<Reservation>>("ReservationList");
            }

            var finalReservationVM = new FinalReservationVM();
            finalReservationVM.Reservations = reservations;

            return View(finalReservationVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(Reservation reservation)
        {
            var room = await _roomRepository.GetRoom(SD.RoomAPIPath + "GetRoom/", reservation.Room.Id);
            reservation.Room = room;

            List<Reservation> reservations = new List<Reservation>();

            if (HttpContext.Session.Get<IEnumerable<Reservation>>("ReservationList") != null
                && HttpContext.Session.Get<IEnumerable<Reservation>>("ReservationList").Count() > 0)
            {
                //session exsits
                reservations = HttpContext.Session.Get<List<Reservation>>("ReservationList");
            }

            reservations.Add(reservation);

            HttpContext.Session.Set("ReservationList", reservations);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            List<Reservation> reservations = new List<Reservation>();
            if (HttpContext.Session.Get<IEnumerable<Reservation>>("ReservationList") != null
                && HttpContext.Session.Get<IEnumerable<Reservation>>("ReservationList").Count() > 0)
            {
                //session exsits
                reservations = HttpContext.Session.Get<List<Reservation>>("ReservationList");
            }

            reservations.Remove(reservations.FirstOrDefault(r => r.Room.Id == id));

            HttpContext.Session.Set("ReservationList", reservations);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> MakeReservation(FinalReservationVM finalReservationVM)
        {

            //Check If Payer Exist or not
            var contactInfo = await _contactInfoRepository.GetContactInformation(SD.ContactInfoAPIPath + "GetContactInformation/email/", finalReservationVM.ContactInformation.EmailAddress);
            int contactInfoId;
            double totalPriceAfterDiscount = 0;
            if (contactInfo != null)
            {
                //update contact info
                finalReservationVM.ContactInformation.Id = contactInfo.Id;
                await _contactInfoRepository.UpdateContactInformation(SD.ContactInfoAPIPath + "UpdateContactInformation", finalReservationVM.ContactInformation);
                contactInfoId = contactInfo.Id;
                totalPriceAfterDiscount = (finalReservationVM.TotalPrice * 5) / 100;
            }
            else
            {
                //first time
                contactInfoId = await _contactInfoRepository.CreateContactInformation(SD.ContactInfoAPIPath + "CreateContactInformation", finalReservationVM.ContactInformation);
                totalPriceAfterDiscount = finalReservationVM.TotalPrice;
            }

            //Insert New Booking
            var booking = new Bookings()
            {
                TotalPrice = finalReservationVM.TotalPrice,
                TotalPriceAfterDiscount = totalPriceAfterDiscount,
                CreatedAt = DateTime.Now
            };
            var bookingId = await _bookingRepository.CreateBooking(SD.BookingAPIPath + "CreateBookings", booking);


            //Insert Reservation
            for (int i = 0; i < finalReservationVM.Reservations.Count; i++)
            {
                finalReservationVM.Reservations[i].BookingId = bookingId;
                finalReservationVM.Reservations[i].ContactInformationId = contactInfoId;
                finalReservationVM.Reservations[i].RoomId = finalReservationVM.Reservations[i].Room.Id;
                finalReservationVM.Reservations[i].Status = 1;
                finalReservationVM.Reservations[i].Room = null;
            }
            await _reservationRepository.AddBulkReservation(SD.ReservationAPIPath + "AddBulkReservation/", finalReservationVM.Reservations);

            HttpContext.Session.Remove("ReservationList");
            
            return RedirectToAction(nameof(BookSent));
        }

        public IActionResult BookSent()
        {
            return View();
        }
    }
}
