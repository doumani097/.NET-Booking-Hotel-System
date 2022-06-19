using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookingRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<int> CreateBooking(string url, Bookings bookings)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (bookings != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(bookings), Encoding.UTF8, "application/json");
            }
            else
            {
                return 0;
            }

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(jsonString);
            }
            return 0;
        }

        public async Task<bool> DeleteBooking(string url, Bookings bookings)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (bookings != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(bookings), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Bookings> GetBooking(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Bookings>(jsonString);
            }
            return null;
        }

        public async Task<IList<Bookings>> GetBookings(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Bookings>>(jsonString);
            }
            return null;
        }
        

        public async Task<bool> UpdateBooking(string url, Bookings Bookings)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (Bookings != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(Bookings), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
