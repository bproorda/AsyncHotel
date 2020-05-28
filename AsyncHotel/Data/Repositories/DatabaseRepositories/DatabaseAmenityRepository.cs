using AsyncHotel.Data.Repositories.IRepositories;
using AsyncHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories.DatabaseRepositories
{
    public class DatabaseAmenityRepository : IAmenityRepository
    {

        private readonly HotelDbContext _context;

        public DatabaseAmenityRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> DeleteAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return null;
            }

            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            return amenity;

        }

        public async Task<IEnumerable<Amenity>> GetAllAmenities()
        
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> GetOneAmenity(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<Amenity> SaveNewAmenity(Amenity Amenity)
        {
            _context.Amenities.Add(Amenity);
            await _context.SaveChangesAsync();
            return Amenity;
        }

        public async Task<bool> UpdateAmenity(int id, Amenity Amenity)
        {
            _context.Entry(Amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool AmenityExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }
    }
}
