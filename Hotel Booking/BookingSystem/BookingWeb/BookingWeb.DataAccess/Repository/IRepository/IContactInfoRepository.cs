using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IContactInfoRepository
    {
        Task<IList<ContactInformation>> GetContactInformations(string url);
        Task<ContactInformation> GetContactInformation(string url, int id);
        Task<ContactInformation> GetContactInformation(string url, string emailAddress);
        Task<int> CreateContactInformation(string url, ContactInformation contactInfo);
        Task<bool> UpdateContactInformation(string url, ContactInformation contactInfo);
        Task<bool> DeleteContactInformation(string url, ContactInformation contactInfo);
    }
}
