using data = DO.Objects;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using DAL.EF;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BS
{
    public partial class Usuario : ICrud<data.Usuario>
    {

        private SolutionDbContext context;
        public Usuario(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Usuario t)
        {
            new DAL.Usuario(context).Delete(t);
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return new DAL.Usuario(context).GetAll();
        }

        public data.Usuario GetOneById(int id)
        {
            return new DAL.Usuario(context).GetOneById(id);
        }

        public void Insert(data.Usuario t)
        {
            new DAL.Usuario(context).Insert(t);
        }

        public void Update(data.Usuario t)
        {
            new DAL.Usuario(context).Update(t);
        }
    }
}
