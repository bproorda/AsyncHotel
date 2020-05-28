using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories.IRepositories
{
    public interface IAmenityRepository
    {
        Task<IEnumerable<Amenity>> GetAllAmenities();

        Task<Amenity> GetOneAmenity(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns>Amenity exists or not</returns>
        Task<bool> UpdateAmenity(int id, Amenity Amenity);


        Task<Amenity> SaveNewAmenity(Amenity Amenity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deleted Amenity</returns>
        Task<Amenity> DeleteAmenity(int id);
    }
}
