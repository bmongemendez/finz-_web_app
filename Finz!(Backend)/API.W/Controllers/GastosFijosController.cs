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
    public class GastosFijossController : ControllerBase
    {
        private readonly FinzContext _context;

        public GastosFijossController(FinzContext context)
        {
            _context = context;
        }

        // GET: api/GastosFijos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastosFijos>>> GetGastosFijos()
        {
            return await _context.GastosFijos.ToListAsync();
        }

        // GET: api/GastosFijos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GastosFijos>> GetGastosFijos(int id)
        {
            var gastosFijos = await _context.GastosFijos.FindAsync(id);

            if (gastosFijos == null)
            {
                return NotFound();
            }

            return gastosFijos;
        }

        // PUT: api/GastosFijos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastosFijos(int id, GastosFijos gastosFijos)
        {
            if (id != gastosFijos.IdGastoFijo)
            {
                return BadRequest();
            }

            _context.Entry(gastosFijos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastosFijosExists(id))
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

        // POST: api/GastosFijos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GastosFijos>> PostGastosFijos(GastosFijos gastosFijos)
        {
            _context.GastosFijos.Add(gastosFijos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGastosFijos", new { id = gastosFijos.IdGastoFijo }, gastosFijos);
        }

        // DELETE: api/GastosFijos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GastosFijos>> DeleteGastosFijos(int id)
        {
            var gastosFijos = await _context.GastosFijos.FindAsync(id);
            if (gastosFijos == null)
            {
                return NotFound();
            }

            _context.GastosFijos.Remove(gastosFijos);
            await _context.SaveChangesAsync();

            return gastosFijos;
        }

        private bool GastosFijosExists(int id)
        {
            return _context.GastosFijos.Any(e => e.IdGastoFijo == id);
        }
    }
}
