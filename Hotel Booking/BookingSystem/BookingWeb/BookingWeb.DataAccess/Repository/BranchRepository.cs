using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public BranchRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateBranch(string url, Branch hotel)
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

        public async Task<bool> DeleteBranch(string url, Branch hotel)
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

        public async Task<Branch> GetBranch(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Branch>(jsonString);
            }
            return null;
        }

        public async Task<IList<Branch>> GetBranches(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Branch>>(jsonString);
            }
            return null;
        }
        
        public async Task<IList<Branch>> GetBranches(string url, int hotelId, int locationId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + hotelId + "/" + locationId);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Branch>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateBranch(string url, Branch hotel)
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
