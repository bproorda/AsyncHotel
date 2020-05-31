using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncHotel.Data;
using AsyncHotel.Models;
using AsyncHotel.Data.Repositories;
using AsyncHotel.Models.API;

namespace AsyncHotel.Controllers
{
    [Route("api/Rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        IRoomRepository RoomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this.RoomRepository = roomRepository;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await RoomRepository.GetAllRooms());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await RoomRepository.GetOneRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await RoomRepository.UpdateRoom(id, room);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await RoomRepository.SaveNewRoom(room);

            return CreatedAtAction("GetStudent", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDTO>> DeleteRoom(int id)
        {
            var room = await RoomRepository.DeleteRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpGet("{id}/Amenities")]

        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities(int id)
        {
            //var amenities = await RoomRepository.GetAmenities(id);

            return Ok(await RoomRepository.GetAmenities(id));
        }


    }
}
