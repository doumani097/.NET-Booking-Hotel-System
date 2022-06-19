using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.Models.ViewModels
{
    public class FinalReservationVM
    {
        public FinalReservationVM()
        {
            Reservations = new List<Reservation>();
        }

        public List<Reservation> Reservations { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public double TotalPrice { get; set; }
    }
}
