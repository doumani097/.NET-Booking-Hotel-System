using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public HotelRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateHotel(string url, Hotel hotel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (hotel != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/json");
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

        public async Task<bool> DeleteHotel(string url, Hotel hotel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (hotel != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/json");
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

        public async Task<Hotel> GetHotel(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Hotel>(jsonString);
            }
            return null;
        }

        public async Task<IList<Hotel>> GetHotels(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Hotel>>(jsonString);
            }
            return null;
        }
        
        public async Task<IList<Hotel>> GetHotels(string url, int hotelId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + hotelId);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Hotel>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateHotel(string url, Hotel hotel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (hotel != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(hotel), Encoding.UTF8, "application/json");
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
