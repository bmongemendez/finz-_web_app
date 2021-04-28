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
    public partial class Usuario : ICrud<data.Usuario>
    {

        private Repository<data.Usuario> _repo = null;
        public Usuario(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Usuario>(solutionDbContext);
        }

        public void Delete(data.Usuario t)
        {
            _repo.Delete(t);
            _repo.Commit();

        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Usuario GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Usuario t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Usuario t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
