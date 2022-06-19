using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IBranchRepository
    {
        IList<Branch> GetBranches();
        IList<Branch> GetBranches(int hotelId, int locationId);
        Branch GetBranch(int id);
        void CreateBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void DeleteBranch(Branch branch);
    }
}