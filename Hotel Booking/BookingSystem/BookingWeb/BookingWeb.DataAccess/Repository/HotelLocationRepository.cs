using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class HotelLocationRepository : IHotelLocationRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public HotelLocationRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateHotelLocation(string url, HotelLocation hotelLocation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (hotelLocation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(hotelLocation), Encoding.UTF8, "application/json");
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

        public async Task<bool> DeleteHotelLocation(string url, HotelLocation hotelLocation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (hotelLocation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(hotelLocation), Encoding.UTF8, "application/json");
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

        public async Task<HotelLocation> GetHotelLocation(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HotelLocation>(jsonString);
            }
            return null;
        }

        public async Task<IList<HotelLocation>> GetHotelLocations(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<HotelLocation>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateHotelLocation(string url, HotelLocation hotelLocation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (hotelLocation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(hotelLocation), Encoding.UTF8, "application/json");
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
