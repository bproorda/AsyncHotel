using AsyncHotel.Data;
using AsyncHotel.Models.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncHotel.API.Controllers
{
    public class DatabaseHotelRoomRepository : IHotelRoomRepository
    {
        private readonly HotelDbContext _context;

        public DatabaseHotelRoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Task<HotelRoomDTO> CreateHotelRoom(CreateHotelRoom hotelRoomData)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<HotelRoomDTO>> GetAllHotels()
        {
            throw new System.NotImplementedException();
        }

        public Task<HotelDTO> GetHotelRoomByNumber(int roomNumber, int hotelId)
        {
            throw new System.NotImplementedException();
        }
    }
}