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
    public class SuscriptorController : ControllerBase
    {
        private readonly DbHackathonMegaContext _context;

        public SuscriptorController(DbHackathonMegaContext context)
        {
            _context = context;
        }

        // GET: api/Suscriptor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suscriptor>>> GetSuscriptors()
        {
            return await _context.Suscriptors.ToListAsync();
        }

        // GET: api/Suscriptor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suscriptor>> GetSuscriptor(int id)
        {
            var suscriptor = await _context.Suscriptors.FindAsync(id);

            if (suscriptor == null)
            {
                return NotFound();
            }

            return suscriptor;
        }

        // PUT: api/Suscriptor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuscriptor(int id, Suscriptor suscriptor)
        {
            if (id != suscriptor.Idsuscriptor)
            {
                return BadRequest();
            }

            _context.Entry(suscriptor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuscriptorExists(id))
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

        // POST: api/Suscriptor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suscriptor>> PostSuscriptor(Suscriptor suscriptor)
        {
            _context.Suscriptors.Add(suscriptor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuscriptor", new { id = suscriptor.Idsuscriptor }, suscriptor);
        }

        // DELETE: api/Suscriptor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuscriptor(int id)
        {
            var suscriptor = await _context.Suscriptors.FindAsync(id);
            if (suscriptor == null)
            {
                return NotFound();
            }

            _context.Suscriptors.Remove(suscriptor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuscriptorExists(int id)
        {
            return _context.Suscriptors.Any(e => e.Idsuscriptor == id);
        }
    }
}
