namespace AsyncHotel.Web.Models
{
    public class HotelRoomSummary
    {
        public string Hotel { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        //public RoomDTO Room { get; set; }

        public int RoomId { get; set; }

        //[Column(TypeName = "decimal(18,4)")]
        public double Rate { get; set; }

        public bool PetFriendly { get; set; }
    }
}