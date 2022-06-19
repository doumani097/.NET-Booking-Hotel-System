using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IBranchRepository
    {
        Task<IList<Branch>> GetBranches(string url);
        Task<IList<Branch>> GetBranches(string url, int hotelId, int locationId);
        Task<Branch> GetBranch(string url, int id);
        Task<bool> CreateBranch(string url, Branch hotel);
        Task<bool> UpdateBranch(string url, Branch hotel);
        Task<bool> DeleteBranch(string url, Branch hotel);
    }
}
