using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IContactInformationRepository
    {
        IList<ContactInformation> GetContactInformations();
        ContactInformation GetContactInformation(int id);
        ContactInformation GetContactInformation(string emailAddress);
        int CreateContactInformation(ContactInformation contactInformation);
        void UpdateContactInformation(ContactInformation contactInformation);
        void DeleteContactInformation(ContactInformation contactInformation);
    }
}