using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _db;

        public BranchRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateBranch(Branch branch)
        {
            branch.CreatedAt = System.DateTime.Now;
            _db.Branches.Add(branch);
            _db.SaveChanges();
        }

        public void DeleteBranch(Branch branch)
        {
            _db.Branches.Remove(branch);
            _db.SaveChanges();
        }

        public Branch GetBranch(int id)
        {
            return _db.Branches.Find(id);
        }

        public IList<Branch> GetBranches(int hotelId, int locationId)
        {
            return _db.Branches.Where(b => b.HotelLocation.HotelId == hotelId)
                .Where(b => b.HotelLocation.LocationId == locationId).ToList();
        }
        
        public IList<Branch> GetBranches()
        {
            return _db.Branches.ToList();
        }

        public void UpdateBranch(Branch branch)
        {
            _db.Branches.Update(branch);
            _db.SaveChanges();
        }
    }
}
