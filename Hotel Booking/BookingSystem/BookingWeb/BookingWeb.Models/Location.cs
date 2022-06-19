using System;
using System.ComponentModel.DataAnnotations;

namespace BookingWeb.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}