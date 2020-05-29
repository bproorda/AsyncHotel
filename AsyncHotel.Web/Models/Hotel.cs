using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncHotel.Web.Models
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        //Navigation properites
        public List<HotelRoomSummary> HotelRooms { get; set; }
    }
}
