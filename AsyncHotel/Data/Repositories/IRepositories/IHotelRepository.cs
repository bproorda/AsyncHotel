using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories
{
    public interface IHotelRepository
    {
         Task<IEnumerable<Hotel>> GetAllHotels();

        Task<Hotel> GetOneHotel(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns>hotel exists or not</returns>
        Task<bool> UpdateHotel(int id, Hotel hotel);


        Task<Hotel> SaveNewHotel(Hotel hotel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deleted hotel</returns>
        Task<Hotel> DeleteHotel(int id);
    }
}
