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

namespace AsyncHotel.Controllers
{
    [Route("api/Hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        

        IHotelRepository HotelRepository;

        public HotelsController(IHotelRepository HotelRepository)
        {
            this.HotelRepository = HotelRepository;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            return Ok(await HotelRepository.GetAllHotels());
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await HotelRepository.GetOneHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await HotelRepository.UpdateHotel(id, hotel);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await HotelRepository.SaveNewHotel(hotel);

            return CreatedAtAction("GetStudent", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await HotelRepository.DeleteHotel(id);

            
            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

       
    }
}
