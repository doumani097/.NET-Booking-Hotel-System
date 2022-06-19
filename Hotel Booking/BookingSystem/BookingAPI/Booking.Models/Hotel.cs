using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}