using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {
        private readonly IContactInformationRepository _contactInformationRepository;

        public ContactInfosController(IContactInformationRepository contactInformationRepository)
        {
            _contactInformationRepository = contactInformationRepository;
        }

        [HttpGet]
        [Route("GetAllContactInformations")]
        public IActionResult GetAllContactInformations()
        {
            var ContactInformations = _contactInformationRepository.GetContactInformations();
            return Ok(ContactInformations);
        }
        
        [HttpGet]
        [Route("GetContactInformation/{id}")]
        public IActionResult GetContactInformation(int id)
        {
            var ContactInformation = _contactInformationRepository.GetContactInformation(id);
            if(ContactInformation == null)
            {
                return NotFound();
            }
            return Ok(ContactInformation);
        }
        
        [HttpGet]
        [Route("GetContactInformation/email/{emailAddress}")]
        public IActionResult GetContactInformation(string emailAddress)
        {
            var ContactInformation = _contactInformationRepository.GetContactInformation(emailAddress);
            if(ContactInformation == null)
            {
                return NotFound();
            }
            return Ok(ContactInformation);
        }
        
        [HttpPost]
        [Route("CreateContactInformation")]
        public IActionResult CreateContactInformation(ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                var contactId = _contactInformationRepository.CreateContactInformation(contactInformation);
                return Ok(contactId);
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("UpdateContactInformation")]
        public IActionResult UpdateContactInformation(ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                _contactInformationRepository.UpdateContactInformation(contactInformation);
                return Ok("Updated Successfully...");
            }
            return BadRequest();
        }
        
        [HttpPost]
        [Route("DeleteContactInformation")]
        public IActionResult DeleteContactInformation(ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                _contactInformationRepository.DeleteContactInformation(contactInformation);
                return Ok("Deleted Successfully...");
            }
            return BadRequest();
        }
    }
}
