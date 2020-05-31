using AsyncHotel.Data;
using AsyncHotel.Models;
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

        public async Task<HotelRoomDTO> SaveNewHotelRoom(CreateHotelRoom hotelRoomData, int hotelId)
        {
            var hotelroom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNumber = hotelRoomData.RoomNumber,
                Rate = hotelRoomData.Rate,
                RoomId = hotelRoomData.RoomId,
                PetFriendly = hotelRoomData.PetFriendly
            };
            _context.HotelRooms.Add(hotelroom);
            await _context.SaveChangesAsync();

            var newHotelRoom = await GetHotelRoomByNumber(hotelId, hotelRoomData.RoomNumber);
            return newHotelRoom;
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

        public Task<bool> UpdateHotel(int hotelId, int roomNumber)
        {
            throw new System.NotImplementedException();
        }

        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelId == id);
        }

        public async Task<HotelRoomDTO> DeleteHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomNumber);
            if (hotelRoom == null)
            {
                return null;
            }

            var hotelroomToReturn = await GetHotelRoomByNumber(hotelId, roomNumber);

            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return hotelroomToReturn;
        }
    }
}