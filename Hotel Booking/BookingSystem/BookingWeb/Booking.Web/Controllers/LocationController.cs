using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using BookingWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelLocationRepository _hotelLocationRepository;

        public LocationController(ILocationRepository locationRepository, IHotelRepository hotelRepository, IHotelLocationRepository hotelLocationRepository)
        {
            _locationRepository = locationRepository;
            _hotelRepository = hotelRepository;
            _hotelLocationRepository = hotelLocationRepository;
        }

        public async Task<ActionResult> Index()
        {
            var Locations = await _locationRepository.GetLocations(SD.LocationAPIPath + "GetAllLocations");
            return View(Locations);
        }
        public async Task<ActionResult> UpSert(int? id)
        {
            var hotels = await _hotelRepository.GetHotels(SD.HotelAPIPath + "GetAllHotels");

            var locationUpsertVM = new LocationUpsertVM()
            {
                Hotels = hotels.Select(h => new SelectListItem()
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                })
            };

            if(id == 0 || id == null)
            {
                return View(locationUpsertVM);
            }
            else
            {
                locationUpsertVM.Location = await _locationRepository.GetLocation(SD.LocationAPIPath + "GetLocation/", (int)id);
                return View(locationUpsertVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpSert(LocationUpsertVM locationUpsertVM)
        {
            if (ModelState.IsValid)
            {
                if(locationUpsertVM.Location.Id == 0)
                {
                    //Create
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = files[0].OpenReadStream())
                        {
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                        }
                        locationUpsertVM.Location.Image = p1;
                    }
                    if (await _locationRepository.CreateLocation(SD.LocationAPIPath + "CreateLocation", locationUpsertVM.Location))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    //Update
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = files[0].OpenReadStream())
                        {
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                        }
                        locationUpsertVM.Location.Image = p1;
                    }
                    else
                    {
                        var oldLocation = await _locationRepository.GetLocation(SD.LocationAPIPath + "GetLocation/", locationUpsertVM.Location.Id);
                        locationUpsertVM.Location.Image = oldLocation.Image;
                    }
                    if (await _locationRepository.UpdateLocation(SD.LocationAPIPath + "UpdateLocation", locationUpsertVM.Location))
                    {
                        if(locationUpsertVM.HotelId != 0)
                        {
                            var hotelLocation = new HotelLocation()
                            {
                                HotelId = locationUpsertVM.HotelId,
                                LocationId = locationUpsertVM.Location.Id
                            };
                            await AssignHotelToLocation(hotelLocation);
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(locationUpsertVM.Location);
        }

        public async Task<bool> AssignHotelToLocation(HotelLocation hotelLocation)
        {
            if(hotelLocation.HotelId != 0 || hotelLocation.LocationId != 0)
            {
                if(await _hotelLocationRepository.CreateHotelLocation(SD.HotelLocationAPIPath + "CreateHotelLocation", hotelLocation))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var location = await _locationRepository.GetLocation(SD.LocationAPIPath + "GetLocation/", id);
                if (await _locationRepository.DeleteLocation(SD.LocationAPIPath + "DeleteLocation", location))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
