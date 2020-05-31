using System.ComponentModel;
using System.Text.Json.Serialization;

namespace AsyncHotel.Web.Models
{
    public class HotelRoomSummary
    {
        [JsonPropertyName("hotel")]
        public string Hotel { get; set; }

        [DisplayName("Hotel Id")]
        [JsonPropertyName("hotelId")]
        public int HotelId { get; set; }

        [DisplayName("Room Number")]
        [JsonPropertyName("roomNumber")]
        public int RoomNumber { get; set; }

        [JsonPropertyName("room")]
        public RoomSummary Room { get; set; }

        [DisplayName("Room Id")]
        [JsonPropertyName("RoomId")]
        public int RoomId { get; set; }

        [JsonPropertyName("rate")]
        public double Rate { get; set; }

        [DisplayName("Pet Friendly")]
        [JsonPropertyName("petFriendly")]
        public bool PetFriendly { get; set; }
    }
}