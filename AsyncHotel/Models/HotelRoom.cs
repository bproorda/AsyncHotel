using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class HotelRoom
    {
        public Hotel Hotel { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public Room RoomId { get; set; }

        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }

    }
}
