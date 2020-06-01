using AsyncHotel.Models;
using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories
{
    public interface IHotelRepository
    {
         Task<IEnumerable<HotelDTO>> GetAllHotels();

        Task<HotelDTO> GetOneHotel(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns>hotel exists or not</returns>
        Task<bool> UpdateHotel(int id, Hotel hotel);


        Task<HotelDTO> SaveNewHotel(Hotel hotel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deleted hotel</returns>
        Task<HotelDTO> DeleteHotel(int id);
    }
}
