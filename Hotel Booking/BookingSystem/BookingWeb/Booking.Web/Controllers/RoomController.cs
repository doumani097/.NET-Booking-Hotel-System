using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using BookingWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _RoomRepository;
        private readonly IBranchRepository _branchRepository;

        public RoomController(IRoomRepository RoomRepository, IBranchRepository branchRepository)
        {
            _RoomRepository = RoomRepository;
            _branchRepository = branchRepository;
        }

        public async Task<ActionResult> Index()
        {
            var Rooms = await _RoomRepository.GetRooms(SD.RoomAPIPath + "GetAllRooms");
            return View(Rooms);
        }

        public async Task<ActionResult> UpSert(int? id)
        {
            var branches = await _branchRepository.GetBranches(SD.BranchAPIPath + "GetAllBranches");
            var RoomUpsertVM = new RoomUpsertVM()
            {
                Room = new Room(),
                Branches = branches.Select(b => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
            };

            if(id == 0 || id == null)
            {
                return View(RoomUpsertVM);
            }
            else
            {
                RoomUpsertVM.Room = await _RoomRepository.GetRoom(SD.RoomAPIPath + "GetRoom/", (int)id);
                return View(RoomUpsertVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(RoomUpsertVM RoomUpsertVM)
        {
            if(RoomUpsertVM.Room.Id == 0)
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
                    RoomUpsertVM.Room.Image = p1;
                }
                if (await _RoomRepository.CreateRoom(SD.RoomAPIPath + "CreateRoom", RoomUpsertVM.Room))
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
                    RoomUpsertVM.Room.Image = p1;
                }
                else
                {
                    var oldRoom = await _RoomRepository.GetRoom(SD.RoomAPIPath + "GetRoom/", RoomUpsertVM.Room.Id);
                    RoomUpsertVM.Room.Image = oldRoom.Image;
                }
                if (await _RoomRepository.UpdateRoom(SD.RoomAPIPath + "UpdateRoom", RoomUpsertVM.Room))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(RoomUpsertVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id != 0)
            {
                var Room = await _RoomRepository.GetRoom(SD.RoomAPIPath + "GetRoom/", id);
                if(await _RoomRepository.DeleteRoom(SD.RoomAPIPath + "DeleteRoom", Room))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
