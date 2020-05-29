using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.API
{
    public class HotelRoomDTO
    {
        public string Hotel { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        //[Column(TypeName = "decimal(18,4)")]
        public double Rate { get; set; }

        public bool PetFriendly { get; set; }
    }
}
