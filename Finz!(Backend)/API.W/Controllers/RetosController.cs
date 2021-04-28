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
    public class RetossController : ControllerBase
    {
        private readonly FinzContext _context;

        public RetossController(FinzContext context)
        {
            _context = context;
        }

        // GET: api/Retos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Retos>>> GetRetos()
        {
            return await _context.Retos.ToListAsync();
        }

        // GET: api/Retos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Retos>> GetRetos(int id)
        {
            var retos = await _context.Retos.FindAsync(id);

            if (retos == null)
            {
                return NotFound();
            }

            return retos;
        }

        // PUT: api/Retos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRetos(int id, Retos retos)
        {
            if (id != retos.IdReto)
            {
                return BadRequest();
            }

            _context.Entry(retos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetosExists(id))
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

        // POST: api/Retos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Retos>> PostRetos(Retos retos)
        {
            _context.Retos.Add(retos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRetos", new { id = retos.IdReto }, retos);
        }

        // DELETE: api/Retos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Retos>> DeleteRetos(int id)
        {
            var retos = await _context.Retos.FindAsync(id);
            if (retos == null)
            {
                return NotFound();
            }

            _context.Retos.Remove(retos);
            await _context.SaveChangesAsync();

            return retos;
        }

        private bool RetosExists(int id)
        {
            return _context.Retos.Any(e => e.IdReto == id);
        }
    }
}
