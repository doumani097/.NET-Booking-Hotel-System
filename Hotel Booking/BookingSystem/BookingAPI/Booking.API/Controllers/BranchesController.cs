using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchRepository _branchRepository;

        public BranchesController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [HttpGet]
        [Route("GetAllBranches/{hotelId}/{locationId}")]
        public IActionResult GetAllBranches(int hotelId, int locationId)
        {
            var Branches = _branchRepository.GetBranches(hotelId, locationId);
            return Ok(Branches);
        }
        
        [HttpGet]
        [Route("GetAllBranches")]
        public IActionResult GetAllBranches()
        {
            var Branches = _branchRepository.GetBranches();
            return Ok(Branches);
        }
        
        [HttpGet]
        [Route("GetBranch/{id}")]
        public IActionResult GetBranch(int id)
        {
            var Branch = _branchRepository.GetBranch(id);
            if(Branch == null)
            {
                return NotFound();
            }
            return Ok(Branch);
        }
        
        [HttpPost]
        [Route("CreateBranch")]
        public IActionResult CreateBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.CreateBranch(branch);
                return Ok("Created Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateBranch")]
        public IActionResult UpdateBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.UpdateBranch(branch);
                return Ok("Updated Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteBranch")]
        public IActionResult DeleteBranch(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchRepository.DeleteBranch(branch);
                return Ok("Deleted Successfully...");
            }
            return BadRequest();
        }

    }
}
