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
    public class Retos : ICrud<data.Retos>
    {
        //Definicion de la variable que va implementar el repositorio extendido a utilizar
        //ya que necesitamos agregar el include en los metodos del repository
        private RepositoryRetos _repo = null;

        public Retos(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryRetos(solutionDbContext);
        }

        public void Delete(data.Retos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Retos> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Retos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Retos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Retos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Retos>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Retos> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
