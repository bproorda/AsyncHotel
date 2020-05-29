using AsyncHotel.Models;
using AsyncHotel.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AsyncHotel.Data.Repositories
{
    public class DatabaseHotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public DatabaseHotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<HotelDTO> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }

            var hotelToReturn = await GetOneHotel(id);

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotelToReturn;
        }

        public async Task<IEnumerable<HotelDTO>> GetAllHotels()
        {
            var hotels = await _context.Hotels
                 .Select(hotel => new HotelDTO
                 {
                     Id = hotel.Id,
                     Name = hotel.Name,
                     City = hotel.City,
                     State = hotel.State,

                    HotelRooms = hotel.HotelRooms
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
                             .Select( ra => new RoomAmenityDTO 
                             {
                                 Amenity = ra.Amenity.name,
                             })
                             .ToList(),
                         }
                     })
                     .ToList(),
                 })
                 .ToListAsync();
            return hotels;
        }

        public async Task<HotelDTO> GetOneHotel(int id)
        {
            var hotel = await _context.Hotels
                .Select(hotel => new HotelDTO
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    City = hotel.City,
                    State = hotel.State,
                     HotelRooms = hotel.HotelRooms
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
                     })
                     .ToList(),
                })
                .FirstOrDefaultAsync(hotel => hotel.Id == id);

            return hotel;
        }

        public async Task<HotelDTO> SaveNewHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return await GetOneHotel(hotel.Id);
        }

        public async Task<bool> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool HotelExists(int id)
       {
           return _context.Hotels.Any(e => e.Id == id);
       }
    }
}
