using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Web.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //Navigation properites
        public List<HotelRoomSummary> HotelRooms { get; set; }
    }
}
