using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public LocationRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateLocation(string url, Location location)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (location != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
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

        public async Task<bool> DeleteLocation(string url, Location location)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (location != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
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

        public async Task<Location> GetLocation(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Location>(jsonString);
            }
            return null;
        }

        public async Task<IList<Location>> GetLocations(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Location>>(jsonString);
            }
            return null;
        }
        
        public async Task<IList<Location>> GetLocations(string url, int hotelId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + hotelId);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Location>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateLocation(string url, Location location)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (location != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
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
