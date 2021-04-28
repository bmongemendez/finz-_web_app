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
    public class Dinero : ICrud<data.Dinero>
    {
        //Definicion de la variable que va implementar el repositorio extendido a utilizar
        //ya que necesitamos agregar el include en los metodos del repository
        private RepositoryDinero _repo = null;

        public Dinero(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryDinero(solutionDbContext);
        }

        public void Delete(data.Dinero t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Dinero> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Dinero GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Dinero t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Dinero t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Dinero>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Dinero> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
