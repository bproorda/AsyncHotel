using AsyncHotel.Data;
using AsyncHotel.Models.API;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms(int hotelId)
        {
            var hotelRooms = await _context.HotelRooms
                .Where(hr => hr.HotelId == hotelId)
                .Select(hr => new HotelRoomDTO
                {
                    Hotel = hr.Hotel.Name,
                    HotelId = hr.HotelId,
                    Rate = hr.Rate,
                    RoomId = hr.RoomId,
                    RoomNumber = hr.RoomNumber,
                    PetFriendly = hr.PetFriendly,
                    Room = new RoomDTO
                    {
                        Id = hr.Room.Id,
                        name = hr.Room.name,
                        layout = hr.Room.layout.ToString(),
                        RoomAmenities = hr.Room.RoomAmenities
                             .Select(ra => new RoomAmenityDTO
                             {
                                 Amenity = ra.Amenity.name,
                             })
                             .ToList(),
                    }
                }).ToListAsync();

            return hotelRooms;
        }

        public async Task<HotelRoomDTO> GetHotelRoomByNumber(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms
            .Where(hr => hr.HotelId == hotelId)
            .Where(hr => hr.RoomNumber == roomNumber)
            .Select(hr => new HotelRoomDTO
            {
                Hotel = hr.Hotel.Name,
                HotelId = hr.HotelId,
                Rate = hr.Rate,
                RoomId = hr.RoomId,
                RoomNumber = hr.RoomNumber,
                PetFriendly = hr.PetFriendly,
                Room = new RoomDTO
                {
                    Id = hr.Room.Id,
                    name = hr.Room.name,
                    layout = hr.Room.layout.ToString(),
                    RoomAmenities = hr.Room.RoomAmenities
                         .Select(ra => new RoomAmenityDTO
                         {
                             Amenity = ra.Amenity.name,
                         })
                         .ToList(),
                }
            }).FirstOrDefaultAsync();

            return hotelRoom;
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelId == id);
        }
    }
}