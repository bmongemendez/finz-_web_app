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
    public class UsuariosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public UsuariosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Usuario>>> GetUsuario()
        {
            // Declaramos una variable para traer la informacion
            var aux = new BS.Usuario(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Usuario>, IEnumerable<datamodels.Usuario>>(aux).ToList();
            return mapaux;

        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Usuario>> GetUsuario(String id)
        {
            var usuario = new BS.Usuario(_context).GetOneById(id);

            if (usuario == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Usuario, datamodels.Usuario>(usuario);
            return mapaux;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(String id, datamodels.Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Usuario, data.Usuario>(usuario);
                new BS.Usuario(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Usuario>> PostUsuario(datamodels.Usuario usuario)
        {
            var mapaux = _mapper.Map<datamodels.Usuario, data.Usuario>(usuario);
            new BS.Usuario(_context).Insert(mapaux);

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Usuario>> DeleteUsuario(String id)
        {
            var usuario = new BS.Usuario(_context).GetOneById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            new BS.Usuario(_context).Delete(usuario);
            var mapaux = _mapper.Map<data.Usuario, datamodels.Usuario>(usuario);

            return mapaux;
        }

        private bool UsuarioExists(String id)
        {
            return (new BS.Usuario(_context).GetOneById(id) != null);
        }
    }
}
