using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncHotel.Web.Models
{
    public class RoomSummary
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("roomAmenities")]
        public List<AmenitySummary> RoomAmenities { get; set; }
}

    public class AmenitySummary
    {
        [JsonPropertyName("name")]
        public string amenity { get; set; }
    }
}
