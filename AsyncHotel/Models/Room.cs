using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public Layout layout { get; set; }

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
        public ICollection<RoomAmenity> RoomAmenities { get; set; }



    }
}
