using AsyncHotel.Models;
using AsyncHotel.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();

        Task<RoomDTO> GetOneRoom(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns>hotel exists or not</returns>
        Task<bool> UpdateRoom(int id, Room Room );


        Task<RoomDTO> SaveNewRoom (Room room);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deleted hotel</returns>
        Task<RoomDTO> DeleteRoom(int id);
        Task<IEnumerable<AmenityDTO>> GetAmenities(int roomId);
        Task<AmenityDTO> AddAmenity(int roomId, int amenityId);
    }
}
