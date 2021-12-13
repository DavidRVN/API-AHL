using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiAHL.Data;
using ApiAHL.Models;

namespace ApiAHL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelesController : ControllerBase
    {
        private readonly ApiAHLContext _context;

        public HotelesController(ApiAHLContext context)
        {
            _context = context;
        }

        // GET: Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hoteles>>> getHotels()
        {
            return await _context.Hoteles.ToListAsync();
        }

        // GET: Hotels/Details/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Hoteles>> getHotels(int id)
        {
            var hotels = await _context.Hoteles.FindAsync(id);

            if (hotels == null)
            {
                return NotFound();
            }

            return hotels;
        }

        //Save Hotel

        [HttpPost]
        public async Task<ActionResult<Hoteles>> PostHotel(Hoteles hotel)
        {
            _context.Hoteles.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getHotels", new { id = hotel.idHotel }, hotel);
        }


        //Update(PUT)

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hoteles hotel)
        {
            if (id != hotel.idHotel)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;
           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        //Delete
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hoteles.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hoteles.Remove(hotel);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        private bool HotelesExists(int id)
        {
            return _context.Hoteles.Any(e => e.idHotel == id);
        }
    }
}
