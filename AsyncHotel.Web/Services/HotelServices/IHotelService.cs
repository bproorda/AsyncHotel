using AsyncHotel.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Web.Services
{
    public interface IHotelService
    {
         Task<List<Hotel>> GetAllHotels();

        Task<Hotel> GetOneHotel(int hotelId);
        Task<List<HotelRoomSummary>> GetHotelRooms(int id);
    }
}
