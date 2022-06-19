using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteLink { get; set; }
        [Required]
        public int HotelLocationId { get; set; }
        [ForeignKey(nameof(HotelLocationId))]
        public HotelLocation HotelLocation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}