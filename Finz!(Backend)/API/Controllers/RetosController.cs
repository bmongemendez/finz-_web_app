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
    public class RetosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public RetosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Retos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Retos>>> GetRetos()
        {
            // Declaramos una variable para traer la informacion
            var aux = await new BS.Retos(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Retos>, IEnumerable<datamodels.Retos>>(aux).ToList();
            return mapaux;
            //return await new BS.Retos(_context).GetAllWithAsync();

        }

        // GET: api/Retos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Retos>> GetRetos(int id)
        {
            var retos = await new BS.Retos(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Retos, datamodels.Retos>(retos);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Retos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRetos(int id, datamodels.Retos retos)
        {
            if (id != retos.IdReto)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Retos, data.Retos>(retos);

                new BS.Retos(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<datamodels.Retos>> PostRetos(datamodels.Retos retos)
        {
            var mapaux = _mapper.Map<datamodels.Retos, data.Retos>(retos);

            new BS.Retos(_context).Insert(mapaux);

            return CreatedAtAction("GetRetos", new { id = retos.IdReto }, retos);
        }

        // DELETE: api/Retos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Retos>> DeleteRetos(int id)
        {
            var retos = new BS.Retos(_context).GetOneById(id);
            if (retos == null)
            {
                return NotFound();
            }

            new BS.Retos(_context).Delete(retos);
            var mapaux = _mapper.Map<data.Retos, datamodels.Retos>(retos);


            return mapaux;
        }

        private bool RetosExists(int id)
        {
            return (new BS.Retos(_context).GetOneById(id) != null);
        }
    }
}
