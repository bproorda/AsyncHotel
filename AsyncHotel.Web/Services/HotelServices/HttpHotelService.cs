using AsyncHotel.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsyncHotel.Web.Services
{
    public class HttpHotelService : IHotelService
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://asynchotelapibpr13.azurewebsites.net/api/")
        };
        public async Task<List<Hotel>> GetAllHotels()
        {
        var responseStream = await httpClient.GetStreamAsync("Hotels");
        List<Hotel> result = await JsonSerializer.DeserializeAsync<List<Hotel>>(responseStream);
        return result;
    }

        public async Task<List<HotelRoomSummary>> GetHotelRooms(int id)
        {
            string address = $"Hotels/{id}/Rooms";
            var responseStream = await httpClient.GetStreamAsync(address);
            List<HotelRoomSummary> result = await JsonSerializer.DeserializeAsync<List<HotelRoomSummary>>(responseStream);
            return result;
        }

        public async Task<Hotel> GetOneHotel(int hotelId)
        {
            string address = $"Hotels/{hotelId}";
            var responseStream = await httpClient.GetStreamAsync(address);
            Hotel result = await JsonSerializer.DeserializeAsync<Hotel>(responseStream);
            return result;
        }
    }
}
