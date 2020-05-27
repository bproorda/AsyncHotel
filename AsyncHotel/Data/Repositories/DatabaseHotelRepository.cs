using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories
{
    public class DatabaseHotelRepository : IHotelRepository
    {
        public Task<Hotel> DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hotel>> GetAllHotels()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetOneHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> SaveNewHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHotel(int id, Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
