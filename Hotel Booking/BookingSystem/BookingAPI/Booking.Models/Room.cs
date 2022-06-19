using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int MaxNoOfPersons { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public double PricePerNight { get; set; }
        [Required]
        public int BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
