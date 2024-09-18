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
    public class CuadrillaController : ControllerBase
    {
        private readonly DbHackathonMegaContext _context;

        public CuadrillaController(DbHackathonMegaContext context)
        {
            _context = context;
        }

        // GET: api/Cuadrilla
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuadrilla>>> GetCuadrillas()
        {
            return await _context.Cuadrillas.ToListAsync();
        }

        // GET: api/Cuadrilla/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuadrilla>> GetCuadrilla(int id)
        {
            var cuadrilla = await _context.Cuadrillas.FindAsync(id);

            if (cuadrilla == null)
            {
                return NotFound();
            }

            return cuadrilla;
        }

        // PUT: api/Cuadrilla/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuadrilla(int id, Cuadrilla cuadrilla)
        {
            if (id != cuadrilla.Idcuadrilla)
            {
                return BadRequest();
            }

            _context.Entry(cuadrilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuadrillaExists(id))
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

        // POST: api/Cuadrilla
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuadrilla>> PostCuadrilla(Cuadrilla cuadrilla)
        {
            _context.Cuadrillas.Add(cuadrilla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuadrilla", new { id = cuadrilla.Idcuadrilla }, cuadrilla);
        }

        // DELETE: api/Cuadrilla/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuadrilla(int id)
        {
            var cuadrilla = await _context.Cuadrillas.FindAsync(id);
            if (cuadrilla == null)
            {
                return NotFound();
            }

            _context.Cuadrillas.Remove(cuadrilla);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuadrillaExists(int id)
        {
            return _context.Cuadrillas.Any(e => e.Idcuadrilla == id);
        }
    }
}
