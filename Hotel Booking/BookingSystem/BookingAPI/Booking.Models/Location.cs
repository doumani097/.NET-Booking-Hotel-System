using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}