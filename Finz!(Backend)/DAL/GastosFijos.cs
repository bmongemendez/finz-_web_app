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
    public class GastosFijos : ICrud<data.GastosFijos>
    {
        //Definicion de la variable que va implementar el repositorio extendido a utilizar
        //ya que necesitamos agregar el include en los metodos del repository
        private RepositoryGastosFijos _repo = null;

        public GastosFijos(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryGastosFijos(solutionDbContext);
        }

        public void Delete(data.GastosFijos t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GastosFijos> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GastosFijos GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GastosFijos t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GastosFijos t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.GastosFijos>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.GastosFijos> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
