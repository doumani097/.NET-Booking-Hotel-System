using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using BookingWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Web.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IHotelLocationRepository _hotelLocationRepository;

        public BranchController(IBranchRepository branchRepository, IHotelLocationRepository hotelLocationRepository)
        {
            _branchRepository = branchRepository;
            _hotelLocationRepository = hotelLocationRepository;
        }

        public async Task<ActionResult> Index()
        {
            var branches = await _branchRepository.GetBranches(SD.BranchAPIPath + "GetAllBranches");
            return View(branches);
        }

        public async Task<ActionResult> UpSert(int? id)
        {
            var hotelLocations = await _hotelLocationRepository.GetHotelLocations(SD.HotelLocationAPIPath + "GetAllHotelLocations");
            var branchUpsertVM = new BranchUpsertVM()
            {
                Branch = new Branch(),
                HotelLocations = hotelLocations.Select(hl => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() {
                    Text = hl.Hotel.Name + " in " + hl.Location.City,
                    Value = hl.Id.ToString()
                })
            };

            if(id == 0 || id == null)
            {
                return View(branchUpsertVM);
            }
            else
            {
                branchUpsertVM.Branch = await _branchRepository.GetBranch(SD.BranchAPIPath + "GetBranch/", (int)id);
                return View(branchUpsertVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpSert(BranchUpsertVM branchUpsertVM)
        {
            if(branchUpsertVM.Branch.Id == 0)
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
                    branchUpsertVM.Branch.Image = p1;
                }
                if (await _branchRepository.CreateBranch(SD.BranchAPIPath + "CreateBranch", branchUpsertVM.Branch))
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
                    branchUpsertVM.Branch.Image = p1;
                }
                else
                {
                    var oldBranch = await _branchRepository.GetBranch(SD.BranchAPIPath + "GetBranch/", branchUpsertVM.Branch.Id);
                    branchUpsertVM.Branch.Image = oldBranch.Image;
                }
                if (await _branchRepository.UpdateBranch(SD.BranchAPIPath + "UpdateBranch", branchUpsertVM.Branch))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(branchUpsertVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id != 0)
            {
                var branch = await _branchRepository.GetBranch(SD.BranchAPIPath + "GetBranch/", id);
                if(await _branchRepository.DeleteBranch(SD.BranchAPIPath + "DeleteBranch", branch))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
