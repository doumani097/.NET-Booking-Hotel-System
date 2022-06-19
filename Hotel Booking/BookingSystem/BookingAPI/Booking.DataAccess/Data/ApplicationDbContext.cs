using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<HotelLocation> HotelLocations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
