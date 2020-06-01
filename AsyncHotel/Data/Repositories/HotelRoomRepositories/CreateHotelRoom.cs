namespace AsyncHotel.API.Controllers
{
    public class CreateHotelRoom
    {
        public int RoomNumber { get; set; }

        public double Rate { get; set; }

        public bool PetFriendly { get; set; }

        public int RoomId { get; set; }
        public int HotelId { get; set; }
    }
}