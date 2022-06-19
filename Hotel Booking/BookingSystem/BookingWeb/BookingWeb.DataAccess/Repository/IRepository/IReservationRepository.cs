using BookingWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository.IRepository
{
    public interface IReservationRepository
    {
        Task<IList<Reservation>> GetReservations(string url);
        Task<Reservation> GetReservation(string url, int id);
        Task<bool> CreateReservation(string url, Reservation reservation);
        Task<bool> AddBulkReservation(string url, List<Reservation> reservations);
        Task<bool> UpdateReservation(string url, Reservation reservation);
        Task<bool> DeleteReservation(string url, Reservation reservation);
    }
}
