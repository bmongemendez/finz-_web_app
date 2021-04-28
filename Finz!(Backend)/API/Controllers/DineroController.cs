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
    public class DineroController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public DineroController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Dinero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Dinero>>> GetDinero()
        {
            // Declaramos una variable para traer la informacion
            var aux = await new BS.Dinero(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Dinero>, IEnumerable<datamodels.Dinero>>(aux).ToList();
            return mapaux;
            //return await new BS.Dinero(_context).GetAllWithAsync();

        }

        // GET: api/Dinero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Dinero>> GetDinero(int id)
        {
            var dinero = await new BS.Dinero(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Dinero, datamodels.Dinero>(dinero);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Dinero/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDinero(int id, datamodels.Dinero dinero)
        {
            if (id != dinero.IdDinero)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Dinero, data.Dinero>(dinero);

                new BS.Dinero(_context).Update(mapaux);
            }
            catch (Exception ee)
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

        // POST: api/Dinero
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Dinero>> PostDinero(datamodels.Dinero dinero)
        {
            var mapaux = _mapper.Map<datamodels.Dinero, data.Dinero>(dinero);

            new BS.Dinero(_context).Insert(mapaux);

            return CreatedAtAction("GetDinero", new { id = dinero.IdDinero }, dinero);
        }

        // DELETE: api/Dinero/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Dinero>> DeleteDinero(int id)
        {
            var dinero = new BS.Dinero(_context).GetOneById(id);
            if (dinero == null)
            {
                return NotFound();
            }

            new BS.Dinero(_context).Delete(dinero);
            var mapaux = _mapper.Map<data.Dinero, datamodels.Dinero>(dinero);


            return mapaux;
        }

        private bool DineroExists(int id)
        {
            return (new BS.Dinero(_context).GetOneById(id) != null);
        }
    }
}
