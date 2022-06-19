using BookingAPI.DataAccess.Data;
using BookingAPI.DataAccess.Repository.IRepository;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.DataAccess.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateReservation(Reservation reservation)
        {
            reservation.CreatedAt = System.DateTime.Now;
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
        }
        
        public void AddBulkReservation(List<Reservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                reservation.CreatedAt = System.DateTime.Now;
            }
            _db.Reservations.AddRange(reservations);
            _db.SaveChanges();
        }

        public void DeleteReservation(Reservation reservation)
        {
            _db.Reservations.Remove(reservation);
            _db.SaveChanges();
        }

        public Reservation GetReservation(int id)
        {
            return _db.Reservations.Find(id);
        }

        public IList<Reservation> GetReservations()
        {
            return _db.Reservations.Include(r => r.ContactInformation).Include(r => r.Room).ToList();
        }

        public void UpdateReservation(Reservation reservation)
        {
            _db.Reservations.Update(reservation);
            _db.SaveChanges();
        }
    }
}
