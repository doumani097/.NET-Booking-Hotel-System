using System;
using System.ComponentModel.DataAnnotations;

namespace BookingWeb.Models
{
    public class HotelLocation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
