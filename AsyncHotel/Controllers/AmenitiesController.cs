using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncHotel.Data;
using AsyncHotel.Models;
using AsyncHotel.Data.Repositories.IRepositories;
using AsyncHotel.Models.API;

namespace AsyncHotel.Controllers
{
    [Route("api/Amenities")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {

        IAmenityRepository AmenityRepository;

        public AmenitiesController(IAmenityRepository AmenityRepository)
        {
            this.AmenityRepository = AmenityRepository;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            return Ok(await AmenityRepository.GetAllAmenities());
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            var amenity = await AmenityRepository.GetOneAmenity(id);

            if (amenity == null)
            {
                return NotFound();
            }

            return amenity;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await AmenityRepository.UpdateAmenity(id, amenity);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(Amenity amenity)
        {
            await AmenityRepository.SaveNewAmenity(amenity);

            return CreatedAtAction("GetStudent", new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AmenityDTO>> DeleteAmenity(int id)
        {
            var amenity = await AmenityRepository.DeleteAmenity(id);
            if (amenity == null)
            {
                return NotFound();
            }

            return amenity;
        }

      
    }
}
