using BookingWeb.DataAccess.Repository.IRepository;
using BookingWeb.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingWeb.DataAccess.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReservationRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateReservation(string url, Reservation reservation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (reservation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
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
        
        public async Task<bool> AddBulkReservation(string url, List<Reservation> reservations)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (reservations != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(reservations), Encoding.UTF8, "application/json");
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

        public async Task<bool> DeleteReservation(string url, Reservation reservation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (reservation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
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

        public async Task<Reservation> GetReservation(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Reservation>(jsonString);
            }
            return null;
        }

        public async Task<IList<Reservation>> GetReservations(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Reservation>>(jsonString);
            }
            return null;
        }
        
        public async Task<IList<Reservation>> GetReservations(string url, int reservationId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + reservationId);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Reservation>>(jsonString);
            }
            return null;
        }

        public async Task<bool> UpdateReservation(string url, Reservation reservation)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (reservation != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
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
