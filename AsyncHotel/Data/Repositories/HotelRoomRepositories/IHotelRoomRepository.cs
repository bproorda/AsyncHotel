using AsyncHotel.Models.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncHotel.API.Controllers
{
    public interface IHotelRoomRepository
    {

        Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms(int hotelId);

        Task<HotelRoomDTO> GetHotelRoomByNumber(int roomNumber, int hotelId);

        Task<HotelRoomDTO> CreateHotelRoom(CreateHotelRoom hotelRoomData);
    }
}