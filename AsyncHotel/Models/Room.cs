using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string name { get; set; }

        public Layout layout { get; set; }

        public enum Layout
        {
            Studio,
            OneBedroom,
            TwoBedroom,
                
        }
    }
}
