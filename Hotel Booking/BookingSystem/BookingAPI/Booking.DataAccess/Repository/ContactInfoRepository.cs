using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class ContactInformationRepository : IContactInformationRepository
    {
        private readonly ApplicationDbContext _db;

        public ContactInformationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public int CreateContactInformation(ContactInformation contactInformation)
        {
            contactInformation.CreatedAt = System.DateTime.Now;
            var contactinfo = _db.ContactInformation.Add(contactInformation);
            _db.SaveChanges();
            return contactinfo.Entity.Id;
        }

        public void DeleteContactInformation(ContactInformation contactInformation)
        {
            _db.ContactInformation.Remove(contactInformation);
            _db.SaveChanges();
        }

        public ContactInformation GetContactInformation(int id)
        {
            return _db.ContactInformation.Find(id);
        }
        

        public ContactInformation GetContactInformation(string emailAddress)
        {
            return _db.ContactInformation.FirstOrDefault(c => c.EmailAddress == emailAddress);
        }

        public IList<ContactInformation> GetContactInformations()
        {
            return _db.ContactInformation.ToList();
        }

        public void UpdateContactInformation(ContactInformation contactInformation)
        {
            _db.ContactInformation.Update(contactInformation);
            _db.SaveChanges();
        }
    }
}
