using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingWeb.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public double TotalPriceAfterDiscount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}