using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookingWeb.Models.ViewModels
{
    public class RoomUpsertVM
    {
        public Room Room { get; set; }
        public IEnumerable<SelectListItem> Branches { get; set; }
    }
}
