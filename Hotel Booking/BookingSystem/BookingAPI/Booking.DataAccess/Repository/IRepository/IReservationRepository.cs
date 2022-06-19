using BookingAPI.Models;
using System.Collections.Generic;

namespace BookingAPI.DataAccess.Repository.IRepository
{
    public interface IReservationRepository
    {
        IList<Reservation> GetReservations();
        Reservation GetReservation(int id);
        void CreateReservation(Reservation reservation);
        void AddBulkReservation(List<Reservation> reservations);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
    }
}