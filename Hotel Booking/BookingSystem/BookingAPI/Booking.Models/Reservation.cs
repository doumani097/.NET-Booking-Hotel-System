using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }
        [Required]
        public int ContactInformationId { get; set; }
        [ForeignKey(nameof(ContactInformationId))]
        public ContactInformation ContactInformation { get; set; }
        [Required]
        public int NoOfPersons { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public int Status { get; set; }
        [Required]
        public int BookingId { get; set; }
        [ForeignKey(nameof(BookingId))]
        public Bookings Bookings { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
