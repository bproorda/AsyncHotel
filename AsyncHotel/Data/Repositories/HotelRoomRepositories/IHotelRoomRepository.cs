using AsyncHotel.Models.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncHotel.API.Controllers
{
    public interface IHotelRoomRepository
    {

        Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms(int hotelId);

        Task<HotelRoomDTO> GetHotelRoomByNumber(int hotelId, int roomNumber);

        Task<HotelRoomDTO> SaveNewHotelRoom(CreateHotelRoom hotelRoomData, int hotelId);

        Task<bool> UpdateHotel(int hotelId, int roomNumber);

        Task<HotelRoomDTO> DeleteHotelRoom(int hotelId, int roomNumber);
    }
}