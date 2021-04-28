using data = DO.Objects;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using DAL.Repository;
using DAL.EF;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class Categorias : ICrud<data.Categorias>
    {

        private Repository<data.Categorias> _repo = null;
        public Categorias(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Categorias>(solutionDbContext);
        }

        public void Delete(data.Categorias t)
        {
            _repo.Delete(t);
            _repo.Commit();

        }

        public IEnumerable<data.Categorias> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Categorias GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.Categorias GetOneById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Categorias t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Categorias t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
