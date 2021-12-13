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
    public class HabitacionesController : ControllerBase
    {
        private readonly ApiAHLContext _context;

        public HabitacionesController(ApiAHLContext context)
        {
            _context = context;
        }

        // GET: Habitaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitaciones>>> getHabitaciones()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        // GET: Hotels/Details/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Habitaciones>> getHabitaciones(int id)
        {
            var habitaciones = await _context.Habitaciones.SingleOrDefaultAsync(h => h.hotelasignado == id);

            return habitaciones;
        }

        // GET: Hotels/Hotels/5
       /* [HttpGet("{id}")]
         public async Task<ActionResult<Habitaciones>> getHabitacionesHotel(int id)
         {
             var habitaciones = await _context.Habitaciones.SingleOrDefaultAsync(h => h.hotelasignado == id);

             return habitaciones;
         }*/



        //Save Hotel

        [HttpPost]
        public async Task<ActionResult<Habitaciones>> PostHabitacion(Habitaciones habitacion)
        {
            _context.Habitaciones.Add(habitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getHabitaciones", new { id = habitacion.idHabitacion }, habitacion);
        }


        //Update(PUT)

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Habitaciones habitacion)
        {
            if (id != habitacion.idHabitacion)
            {
                return BadRequest();
            }

            _context.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionesExists(id))
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
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.Habitaciones.Remove(habitacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HabitacionesExists(int id)
        {
            return _context.Habitaciones.Any(e => e.idHabitacion == id);
        }
    }
}
