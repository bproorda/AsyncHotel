using AsyncHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncHotel.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();

        Task<Room> GetOneRoom(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hotel"></param>
        /// <returns>hotel exists or not</returns>
        Task<bool> UpdateRoom(int id, Room Room );


        Task<Room> SaveNewRoom (Room room);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deleted hotel</returns>
        Task<Room> DeleteRoom(int id);
    }
}
