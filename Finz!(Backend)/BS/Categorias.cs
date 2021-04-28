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
    public partial class Categorias : ICrud<data.Categorias>
    {

        private SolutionDbContext context;
        public Categorias(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Categorias t)
        {
            new DAL.Categorias(context).Delete(t);
        }

        public IEnumerable<data.Categorias> GetAll()
        {
            return new DAL.Categorias(context).GetAll();
        }

        public data.Categorias GetOneById(int id)
        {
            return new DAL.Categorias(context).GetOneById(id);
        }

        public void Insert(data.Categorias t)
        {
            new DAL.Categorias(context).Insert(t);
        }

        public void Update(data.Categorias t)
        {
            new DAL.Categorias(context).Update(t);
        }
    }
}
