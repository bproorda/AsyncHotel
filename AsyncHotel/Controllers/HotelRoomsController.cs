using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncHotel.Data;
using AsyncHotel.Models;

namespace AsyncHotel.API.Controllers
{
    [Route("api/Hotels/{HotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
      

        IHotelRoomRepository hotelRoomRepository;

        public HotelRoomsController(IHotelRoomRepository hotelRoomRepository)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms( int HotelId)
        {
            return Ok(await hotelRoomRepository.GetAllHotelRooms(HotelId));
        }

        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        public /*async*/ Task<ActionResult<HotelRoom>> GetHotelRoom(int id)
        {
            /*var hotelRoom = await _context.HotelRooms.FindAsync(id);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;*/
            return default;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public /*async*/ Task<IActionResult> PutHotelRoom(int id, HotelRoom hotelRoom)
        {
            /* if (id != hotelRoom.HotelId)
             {
                 return BadRequest();
             }

             _context.Entry(hotelRoom).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!HotelRoomExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();*/
            return default;
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public /*async*/ Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            /* _context.HotelRooms.Add(hotelRoom);
             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateException)
             {
                 if (HotelRoomExists(hotelRoom.HotelId))
                 {
                     return Conflict();
                 }
                 else
                 {
                     throw;
                 }
             }

             return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);*/
            return default;
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public /*async*/ Task<ActionResult<HotelRoom>> DeleteHotelRoom(int id)
        {
            /*var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return hotelRoom;*/
            return  default;
        }

       
    }
}
