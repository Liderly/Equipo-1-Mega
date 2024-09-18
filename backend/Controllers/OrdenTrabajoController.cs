using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly DbHackathonMegaContext _context;

        public OrdenTrabajoController(DbHackathonMegaContext context)
        {
            _context = context;
        }

        // GET: api/OrdenTrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenTrabajo>>> GetOrdenTrabajos()
        {
            return await _context.OrdenTrabajos.ToListAsync();
        }

        // GET: api/OrdenTrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenTrabajo>> GetOrdenTrabajo(int id)
        {
            var ordenTrabajo = await _context.OrdenTrabajos.FindAsync(id);

            if (ordenTrabajo == null)
            {
                return NotFound();
            }

            return ordenTrabajo;
        }

        // PUT: api/OrdenTrabajo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenTrabajo(int id, OrdenTrabajo ordenTrabajo)
        {
            if (id != ordenTrabajo.Idorden)
            {
                return BadRequest();
            }

            _context.Entry(ordenTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenTrabajoExists(id))
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

        // POST: api/OrdenTrabajo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenTrabajo>> PostOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            _context.OrdenTrabajos.Add(ordenTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenTrabajo", new { id = ordenTrabajo.Idorden }, ordenTrabajo);
        }

        // DELETE: api/OrdenTrabajo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenTrabajo(int id)
        {
            var ordenTrabajo = await _context.OrdenTrabajos.FindAsync(id);
            if (ordenTrabajo == null)
            {
                return NotFound();
            }

            _context.OrdenTrabajos.Remove(ordenTrabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenTrabajoExists(int id)
        {
            return _context.OrdenTrabajos.Any(e => e.Idorden == id);
        }
    }
}
