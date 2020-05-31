using System.Text.Json.Serialization;

namespace AsyncHotel.Web.Models
{
    public class HotelRoomSummary
    {
        [JsonPropertyName("hotel")]
        public string Hotel { get; set; }


        [JsonPropertyName("hotelId")]
        public int HotelId { get; set; }


        [JsonPropertyName("roomNumber")]
        public int RoomNumber { get; set; }

        //public RoomDTO Room { get; set; }


        [JsonPropertyName("RoomId")]
        public int RoomId { get; set; }

        [JsonPropertyName("rate")]
        public double Rate { get; set; }


        [JsonPropertyName("petFriendly")]
        public bool PetFriendly { get; set; }
    }
}