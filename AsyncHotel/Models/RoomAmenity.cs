using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class RoomAmenity
    {
        public Amenity Amenity { get; set; }

        public Room Room { get; set; }

        public int AmenityId { get; set; }

        public int RoomId { get; set; }
    }
}
