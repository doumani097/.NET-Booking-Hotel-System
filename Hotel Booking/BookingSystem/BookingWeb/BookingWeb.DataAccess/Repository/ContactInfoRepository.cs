using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContactInfoRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<int> CreateContactInformation(string url, ContactInformation contactInformation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (contactInformation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(contactInformation), Encoding.UTF8, "application/json");
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
            else
            {
                return 0;
            }
        }

        public async Task<bool> DeleteContactInformation(string url, ContactInformation contactInformation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (contactInformation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(contactInformation), Encoding.UTF8, "application/json");
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

        public async Task<ContactInformation> GetContactInformation(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ContactInformation>(jsonString);
            }
            return null;
        }
        
        public async Task<ContactInformation> GetContactInformation(string url, string emailAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + emailAddress);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ContactInformation>(jsonString);
            }
            return null;
        }

        public async Task<IList<ContactInformation>> GetContactInformations(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ContactInformation>>(jsonString);
            }
            return null;
        }
        
        public async Task<IList<ContactInformation>> GetContactInformations(string url, int contactInformation)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + contactInformation);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<ContactInformation>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateContactInformation(string url, ContactInformation contactInformation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (contactInformation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(contactInformation), Encoding.UTF8, "application/json");
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
