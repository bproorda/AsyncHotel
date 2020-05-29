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
            BaseAddress = new Uri("https://localhost:44372/api/")
        };
        public async Task<List<Hotel>> GetAllHotels()
        {
        var responseStream = await httpClient.GetStreamAsync("Hotels");
        List<Hotel> result = await JsonSerializer.DeserializeAsync<List<Hotel>>(responseStream);
        return result;
    }
    }
}
