using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using BookingWeb.Models.ViewModels;
using BookingWeb.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelRepository _hotelRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IRoomRepository _roomRepository;

        public HomeController(ILogger<HomeController> logger, 
            IHotelRepository hotelRepository,
            ILocationRepository locationRepository,
            IBranchRepository branchRepository,
            IRoomRepository roomRepository)
        {
            _logger = logger;
            _hotelRepository = hotelRepository;
            _locationRepository = locationRepository;
            _branchRepository = branchRepository;
            _roomRepository = roomRepository;
        }

        public async Task<IActionResult> Index()
        {
            var hotel = await _hotelRepository.GetHotels(SD.HotelAPIPath + "GetAllHotels");
            return View(hotel);
        }

        public async Task<IActionResult> OurLocations(int id)
        {
            var showLocationsVM = new ShowLocationsVM()
            {
                HotelId = id,
                Locations = await _locationRepository.GetLocations(SD.LocationAPIPath + "GetAllLocations/", id)
            };
            return View(showLocationsVM);
        }

        public async Task<IActionResult> Branches(int hotelId, int locationId)
        {
            var branches = await _branchRepository.GetBranches(SD.BranchAPIPath + "GetAllBranches/", hotelId, locationId);
            return View(branches);
        }
        
        public async Task<IActionResult> Rooms(int branchId)
        {
            var rooms = await _roomRepository.GetRooms(SD.RoomAPIPath + "GetAllRooms/", branchId);
            return View(rooms);
        }
        public async Task<IActionResult> Reserve(int roomId)
        {
            var reservation = new Reservation();
            reservation.Room = await _roomRepository.GetRoom(SD.RoomAPIPath + "GetRoom/", roomId);

            return View(reservation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
