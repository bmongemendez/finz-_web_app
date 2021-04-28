using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AhorrosController : ControllerBase
    {
        private readonly FinzContext _context;

        public AhorrosController(FinzContext context)
        {
            _context = context;
        }

        // GET: api/Ahorros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ahorros>>> GetAhorros()
        {
            return await _context.Ahorros.ToListAsync();
        }

        // GET: api/Ahorros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ahorros>> GetAhorros(int id)
        {
            var ahorros = await _context.Ahorros.FindAsync(id);

            if (ahorros == null)
            {
                return NotFound();
            }

            return ahorros;
        }

        // PUT: api/Ahorros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAhorros(int id, Ahorros ahorros)
        {
            if (id != ahorros.IdAhorros)
            {
                return BadRequest();
            }

            _context.Entry(ahorros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AhorrosExists(id))
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

        // POST: api/Ahorros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ahorros>> PostAhorros(Ahorros ahorros)
        {
            _context.Ahorros.Add(ahorros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAhorros", new { id = ahorros.IdAhorros }, ahorros);
        }

        // DELETE: api/Ahorros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ahorros>> DeleteAhorros(int id)
        {
            var ahorros = await _context.Ahorros.FindAsync(id);
            if (ahorros == null)
            {
                return NotFound();
            }

            _context.Ahorros.Remove(ahorros);
            await _context.SaveChangesAsync();

            return ahorros;
        }

        private bool AhorrosExists(int id)
        {
            return _context.Ahorros.Any(e => e.IdAhorros == id);
        }
    }
}
