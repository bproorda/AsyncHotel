using AsyncHotel.Data.Repositories.IRepositories;
using AsyncHotel.Models;
using AsyncHotel.Models.API;
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

        public async Task<AmenityDTO> DeleteAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return null;
            }

            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            var amenityToReturn = await GetOneAmenity(id);

            return amenityToReturn;

        }

        public async Task<IEnumerable<AmenityDTO>> GetAllAmenities()
        
        {
            var amenities = await _context.Amenities
               .Select(amenity => new AmenityDTO
               {
                   Id = amenity.Id,
                   name = amenity.name
               })
               .ToListAsync();

                return amenities;
        }

        public async Task<AmenityDTO> GetOneAmenity(int id)
        {
            var amenity = await _context.Amenities
              .Select(amenity => new AmenityDTO
              {
                  Id = amenity.Id,
                  name = amenity.name
              })
              .FirstOrDefaultAsync(amenity => amenity.Id == id);

            return amenity;
        }

        public async Task<AmenityDTO> SaveNewAmenity(Amenity Amenity)
        {
            _context.Amenities.Add(Amenity);
            await _context.SaveChangesAsync();
            var amenityToReturn = GetOneAmenity(Amenity.Id);

            return await amenityToReturn;
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
