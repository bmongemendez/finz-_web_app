using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using AutoMapper;
using datamodels = API.DataModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AhorrosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public AhorrosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ahorros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Ahorros>>> GetAhorros()
        {
            // Declaramos una variable para traer la informacion
            var aux = await new BS.Ahorros(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Ahorros>, IEnumerable<datamodels.Ahorros>>(aux).ToList();
            return mapaux;
            //return await new BS.Ahorros(_context).GetAllWithAsync();

        }

        // GET: api/Ahorros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Ahorros>> GetAhorros(int id)
        {
            var ahorros = await new BS.Ahorros(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Ahorros, datamodels.Ahorros>(ahorros);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Ahorros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAhorros(int id, datamodels.Ahorros ahorros)
        {
            if (id != ahorros.IdAhorros)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Ahorros, data.Ahorros>(ahorros);

                new BS.Ahorros(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<datamodels.Ahorros>> PostAhorros(datamodels.Ahorros ahorros)
        {
            var mapaux = _mapper.Map<datamodels.Ahorros, data.Ahorros>(ahorros);

            new BS.Ahorros(_context).Insert(mapaux);

            return CreatedAtAction("GetAhorros", new { id = ahorros.IdAhorros }, ahorros);
        }

        // DELETE: api/Ahorros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Ahorros>> DeleteAhorros(int id)
        {
            var ahorros = new BS.Ahorros(_context).GetOneById(id);
            if (ahorros == null)
            {
                return NotFound();
            }

            new BS.Ahorros(_context).Delete(ahorros);
            var mapaux = _mapper.Map<data.Ahorros, datamodels.Ahorros>(ahorros);


            return mapaux;
        }

        private bool AhorrosExists(int id)
        {
            return (new BS.Ahorros(_context).GetOneById(id) != null);
        }
    }
}
