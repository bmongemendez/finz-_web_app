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
    // Implementa la interfase IRepositoryGastos
    // Esta interfase se encarga de implementar metodos que se necesitan para devolver la informacion asociada a la tabla de FK(include)
    public class RepositoryGastos : Repository<data.Gastos>, IRepositoryGastos
    {
        //Constructor correspondiente a la case 
        //Parametro Cotnext para poderlo recibir, cargar al Repository y utilizar en esta misma clase
        public RepositoryGastos(SolutionDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Gastos>> GetAllWithAsAsync()
        {
            return await _db.Gastos
                .Include(m => m.IdUsuarioNavigation)
                .Include(m => m.IdCategoriaNavigation)
                .ToListAsync();
        }

        public async Task<Gastos> GetByOneWithAsAsync(int id)   
        {
            return await _db.Gastos
             .Include(m => m.IdUsuarioNavigation)
             .Include(m => m.IdCategoriaNavigation)
             .SingleOrDefaultAsync(m => m.IdGastos == id);
        }

        //Metodo para obtener el context cargado del repository y asi utilizarlo en esta clase
        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
