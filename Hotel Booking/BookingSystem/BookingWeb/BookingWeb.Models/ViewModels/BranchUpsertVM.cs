using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookingWeb.Models.ViewModels
{
    public class BranchUpsertVM
    {
        public Branch Branch { get; set; }
        public IEnumerable<SelectListItem> HotelLocations { get; set; }
    }
}
