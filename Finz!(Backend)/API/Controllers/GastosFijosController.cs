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
    public class GastosFijosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public GastosFijosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GastosFijos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.GastosFijos>>> GetGastosFijos()
        {
            // Declaramos una variable para traer la informacion
            var aux = await new BS.GastosFijos(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.GastosFijos>, IEnumerable<datamodels.GastosFijos>>(aux).ToList();
            return mapaux;
            //return await new BS.GastosFijos(_context).GetAllWithAsync();

        }

        // GET: api/GastosFijos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.GastosFijos>> GetGastosFijos(int id)
        {
            var gastosFijos = await new BS.GastosFijos(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.GastosFijos, datamodels.GastosFijos>(gastosFijos);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/GastosFijos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastosFijos(int id, datamodels.GastosFijos gastosFijos)
        {
            if (id != gastosFijos.IdGastoFijo)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.GastosFijos, data.GastosFijos>(gastosFijos);

                new BS.GastosFijos(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<datamodels.GastosFijos>> PostGastosFijos(datamodels.GastosFijos gastosFijos)
        {
            var mapaux = _mapper.Map<datamodels.GastosFijos, data.GastosFijos>(gastosFijos);

            new BS.GastosFijos(_context).Insert(mapaux);

            return CreatedAtAction("GetGastosFijos", new { id = gastosFijos.IdGastoFijo }, gastosFijos);
        }

        // DELETE: api/GastosFijos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.GastosFijos>> DeleteGastosFijos(int id)
        {
            var gastosFijos = new BS.GastosFijos(_context).GetOneById(id);
            if (gastosFijos == null)
            {
                return NotFound();
            }

            new BS.GastosFijos(_context).Delete(gastosFijos);
            var mapaux = _mapper.Map<data.GastosFijos, datamodels.GastosFijos>(gastosFijos);


            return mapaux;
        }

        private bool GastosFijosExists(int id)
        {
            return (new BS.GastosFijos(_context).GetOneById(id) != null);
        }
    }
}
