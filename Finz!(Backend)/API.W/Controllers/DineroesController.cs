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
    public class DineroesController : ControllerBase
    {
        private readonly FinzContext _context;

        public DineroesController(FinzContext context)
        {
            _context = context;
        }

        // GET: api/Dineroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dinero>>> GetDinero()
        {
            return await _context.Dinero.ToListAsync();
        }

        // GET: api/Dineroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dinero>> GetDinero(int id)
        {
            var dinero = await _context.Dinero.FindAsync(id);

            if (dinero == null)
            {
                return NotFound();
            }

            return dinero;
        }

        // PUT: api/Dineroes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDinero(int id, Dinero dinero)
        {
            if (id != dinero.IdDinero)
            {
                return BadRequest();
            }

            _context.Entry(dinero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DineroExists(id))
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

        // POST: api/Dineroes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dinero>> PostDinero(Dinero dinero)
        {
            _context.Dinero.Add(dinero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDinero", new { id = dinero.IdDinero }, dinero);
        }

        // DELETE: api/Dineroes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dinero>> DeleteDinero(int id)
        {
            var dinero = await _context.Dinero.FindAsync(id);
            if (dinero == null)
            {
                return NotFound();
            }

            _context.Dinero.Remove(dinero);
            await _context.SaveChangesAsync();

            return dinero;
        }

        private bool DineroExists(int id)
        {
            return _context.Dinero.Any(e => e.IdDinero == id);
        }
    }
}
