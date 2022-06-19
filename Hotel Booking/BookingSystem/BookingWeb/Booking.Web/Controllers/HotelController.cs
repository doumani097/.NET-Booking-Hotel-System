using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<ActionResult> Index()
        {
            var hotels = await _hotelRepository.GetHotels(SD.HotelAPIPath + "GetAllHotels");
            return View(hotels);
        }
        public async Task<ActionResult> UpSert(int? id)
        {
            if(id == 0 || id == null)
            {
                return View();
            }
            else
            {
                var hotel = await _hotelRepository.GetHotel(SD.HotelAPIPath + "GetHotel/", (int)id);
                return View(hotel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                if(hotel.Id == 0)
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
                        hotel.Image = p1;
                    }
                    if (await _hotelRepository.CreateHotel(SD.HotelAPIPath + "CreateHotel", hotel))
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
                        hotel.Image = p1;
                    }
                    else
                    {
                        var oldHotel = await _hotelRepository.GetHotel(SD.HotelAPIPath + "GetHotel/", hotel.Id);
                        hotel.Image = oldHotel.Image;
                    }
                    if (await _hotelRepository.UpdateHotel(SD.HotelAPIPath + "UpdateHotel", hotel))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(hotel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id != 0)
            {
                var hotel = await _hotelRepository.GetHotel(SD.HotelAPIPath + "GetHotel/", id);
                if(await _hotelRepository.DeleteHotel(SD.HotelAPIPath + "DeleteHotel", hotel))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
