using System.Collections.Generic;

namespace BookingWeb.Models.ViewModels
{
    public class ShowLocationsVM
    {
        public int HotelId { get; set; }
        public IList<Location> Locations { get; set; }
    }
}
