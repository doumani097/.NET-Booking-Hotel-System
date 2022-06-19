using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public RoomRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateRoom(string url, Room room)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (room != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
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

        public async Task<bool> DeleteRoom(string url, Room room)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (room != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
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

        public async Task<Room> GetRoom(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Room>(jsonString);
            }
            return null;
        }

        public async Task<IList<Room>> GetRooms(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Room>>(jsonString);
            }
            return null;
        }
        
        public async Task<IList<Room>> GetRooms(string url, int branchId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + branchId);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Room>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateRoom(string url, Room room)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (room != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
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
