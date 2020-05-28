using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class HotelRoom
    {
        public Hotel Hotel { get; set; }

        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        //[Column(TypeName = "decimal(18,4)")]
        public double Rate { get; set; }

        public bool PetFriendly { get; set; }

    }
}
