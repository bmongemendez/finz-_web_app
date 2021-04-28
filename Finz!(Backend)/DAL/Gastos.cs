using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using data = DO.Objects;

namespace DAL
{
    public class Gastos : ICrud<data.Gastos>
    {
        //Definicion de la variable que va implementar el repositorio extendido a utilizar
        //ya que necesitamos agregar el include en los metodos del repository
        private RepositoryGastos _repo = null;

        public Gastos(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryGastos(solutionDbContext);
        }

        public void Delete(data.Gastos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Gastos> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Gastos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Gastos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Gastos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Gastos>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Gastos> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
