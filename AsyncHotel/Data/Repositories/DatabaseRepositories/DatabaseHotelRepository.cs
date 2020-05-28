using AsyncHotel.Models;
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

        public async Task<Hotel> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetOneHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<Hotel> SaveNewHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
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
