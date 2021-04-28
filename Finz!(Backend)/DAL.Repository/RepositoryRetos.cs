using DAL.EF;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    // Clase que es una extension de repository 
    // Implementa la interfase IRepositoryRetos
    // Esta interfase se encarga de implementar metodos que se necesitan para devolver la informacion asociada a la tabla de FK(include)
    public class RepositoryRetos : Repository<data.Retos>, IRepositoryRetos
    {
        //Constructor correspondiente a la case 
        //Parametro Cotnext para poderlo recibir, cargar al Repository y utilizar en esta misma clase
        public RepositoryRetos(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Retos>> GetAllWithAsAsync()
        {
            return await _db.Retos
                .Include(m => m.IdUsuarioNavigation)
                .ToListAsync();
        }

        public async Task<Retos> GetByOneWithAsAsync(int id)
        {
            return await _db.Retos
             .Include(m => m.IdUsuarioNavigation)
             .SingleOrDefaultAsync(m => m.IdReto == id);
        }

        //Metodo para obtener el context cargado del repository y asi utilizarlo en esta clase
        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
