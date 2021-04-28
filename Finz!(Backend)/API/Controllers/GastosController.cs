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
    public class GastosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public GastosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Gastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Gastos>>> GetGastos()
        {
            // Declaramos una variable para traer la informacion
            var aux = await new BS.Gastos(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Gastos>, IEnumerable<datamodels.Gastos>>(aux).ToList();
            return mapaux;
            //return await new BS.Gastos(_context).GetAllWithAsync();

        }

        // GET: api/Gastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Gastos>> GetGastos(int id)
        {
            var gastos = await new BS.Gastos(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Gastos, datamodels.Gastos>(gastos);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Gastos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastos(int id, datamodels.Gastos gastos)
        {
            if (id != gastos.IdGastos)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Gastos, data.Gastos>(gastos);

                new BS.Gastos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GastosExists(id))
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

        // POST: api/Gastos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Gastos>> PostGastos(datamodels.Gastos gastos)
        {
            var mapaux = _mapper.Map<datamodels.Gastos, data.Gastos>(gastos);

            new BS.Gastos(_context).Insert(mapaux);

            return CreatedAtAction("GetGastos", new { id = gastos.IdGastos }, gastos);
        }

        // DELETE: api/Gastos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Gastos>> DeleteGastos(int id)
        {
            var gastos = new BS.Gastos(_context).GetOneById(id);
            if (gastos == null)
            {
                return NotFound();
            }

            new BS.Gastos(_context).Delete(gastos);
            var mapaux = _mapper.Map<data.Gastos, datamodels.Gastos>(gastos);


            return mapaux;
        }

        private bool GastosExists(int id)
        {
            return (new BS.Gastos(_context).GetOneById(id) != null);
        }
    }
}
