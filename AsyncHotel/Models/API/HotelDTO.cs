using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.API
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //Navigation properites
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
