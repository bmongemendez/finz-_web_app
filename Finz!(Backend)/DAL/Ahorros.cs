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
    public class Ahorros : ICrud<data.Ahorros>
    {
        //Definicion de la variable que va implementar el repositorio extendido a utilizar
        //ya que necesitamos agregar el include en los metodos del repository
        private RepositoryAhorros _repo = null;

        public Ahorros(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryAhorros(solutionDbContext);
        }

        public void Delete(data.Ahorros t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Ahorros> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Ahorros GetOneById(String id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Ahorros t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Ahorros t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Ahorros>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Ahorros> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }

        public data.Ahorros GetOneById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
