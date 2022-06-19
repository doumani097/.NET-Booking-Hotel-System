using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookingWeb.Models.ViewModels
{
    public class LocationUpsertVM
    {
        public Location Location { get; set; }
        public IEnumerable<SelectListItem> Hotels { get; set; }
        public int HotelId { get; set; }
    }
}
