using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models.API
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string name { get; set; }

        
        public string layout { get; set; }

        public enum Layout
        {
            Studio,
            OneBedroom,
            TwoBedroom,
            Suite,
            Honeymoon,
            Cabin

        }

        //Navigation properites
        public ICollection<RoomAmenityDTO> RoomAmenities { get; set; }
    }
}
