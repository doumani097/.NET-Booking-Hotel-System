using System;

namespace BookingWeb.Models.ViewModels
{
    public class ReservationVM
    {
        public Room Room { get; set; }
        public int MaxNoOfPersons { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
