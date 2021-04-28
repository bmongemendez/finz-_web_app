using data = DO.Objects;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using DAL.EF;
using System.Threading.Tasks;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BS
{
    public class Dinero : ICrud<data.Dinero>
    {

        private SolutionDbContext context = null;
        public Dinero(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Dinero t)
        {
            new DAL.Dinero(context).Delete(t);
        }

        public IEnumerable<data.Dinero> GetAll()
        {
            return new DAL.Dinero(context).GetAll();
        }

        public data.Dinero GetOneById(int id)
        {
            return new DAL.Dinero(context).GetOneById(id);
        }

        public void Insert(data.Dinero t)
        {
            new DAL.Dinero(context).Insert(t);
        }

        public void Update(data.Dinero t)
        {
            new DAL.Dinero(context).Update(t);
        }

         public async Task<IEnumerable<data.Dinero>> GetAllWithAsync()
        {
            return await new DAL.Dinero(context).GetAllWithAsync();
        }

        public async Task<data.Dinero> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Dinero(context).GetOneByIdWithAsync(id);
        }

        public data.Dinero GetOneById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
