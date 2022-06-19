namespace BookingWeb.Web
{
    public static class SD
    {
        public static string APIBaseUrl = "https://localhost:44305/";
        public static string HotelAPIPath = APIBaseUrl + "api/Hotels/";
        public static string LocationAPIPath = APIBaseUrl + "api/Locations/";
        public static string HotelLocationAPIPath = APIBaseUrl + "api/HotelLocations/";
        public static string BranchAPIPath = APIBaseUrl + "api/Branches/";
        public static string RoomAPIPath = APIBaseUrl + "api/Rooms/";
        public static string ContactInfoAPIPath = APIBaseUrl + "api/ContactInfos/";
        public static string ReservationAPIPath = APIBaseUrl + "api/Reservations/";
        public static string BookingAPIPath = APIBaseUrl + "api/Bookings/";
        public static string AccountAPIPath = APIBaseUrl + "api/Users/";
    }
}
