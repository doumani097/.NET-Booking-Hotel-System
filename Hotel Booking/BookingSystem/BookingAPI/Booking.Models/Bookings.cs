using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public double TotalPriceAfterDiscount { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}