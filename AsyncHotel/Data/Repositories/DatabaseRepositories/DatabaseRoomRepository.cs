﻿using AsyncHotel.Models;
using AsyncHotel.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories
{
    public class DatabaseRoomRepository : IRoomRepository
    {

        private readonly HotelDbContext _context;

        public DatabaseRoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDTO> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            var roomToReturn = await GetOneRoom(id);

            return roomToReturn;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            var rooms = await _context.Rooms
                .Select(room => new RoomDTO 
                {
                    Id = room.Id,
                    name = room.name,
                    layout = room.layout.ToString(),
                    RoomAmenities = room.RoomAmenities
                             .Select(ra => new RoomAmenityDTO
                             {
                                 Amenity = ra.Amenity.name,
                             })
                             .ToList(),

                })
                .ToListAsync();

            return rooms;
        }

        public async Task<RoomDTO> GetOneRoom(int id)
        {
            var room = await _context.Rooms
              .Select(room => new RoomDTO
              {
                  Id = room.Id,
                  name = room.name,
                  layout = room.layout.ToString(),
                  RoomAmenities = room.RoomAmenities
                           .Select(ra => new RoomAmenityDTO
                           {
                               Amenity = ra.Amenity.name,
                           })
                           .ToList(),

              })
              .FirstOrDefaultAsync(room => room.Id == id);

            return room;
        }

        public async Task<RoomDTO> SaveNewRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            var roomToReturn = await GetOneRoom(room.Id);
            return roomToReturn;
        }

        public async Task<bool> UpdateRoom(int id, Room Room)
        {
            _context.Entry(Room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
