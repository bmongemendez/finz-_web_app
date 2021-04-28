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
    public class Ahorros : ICrud<data.Ahorros>
    {

        private SolutionDbContext context = null;
        public Ahorros(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Ahorros t)
        {
            new DAL.Ahorros(context).Delete(t);
        }

        public IEnumerable<data.Ahorros> GetAll()
        {
            return new DAL.Ahorros(context).GetAll();
        }

        public data.Ahorros GetOneById(int id)
        {
            return new DAL.Ahorros(context).GetOneById(id);
        }

        public void Insert(data.Ahorros t)
        {
            new DAL.Ahorros(context).Insert(t);
        }

        public void Update(data.Ahorros t)
        {
            new DAL.Ahorros(context).Update(t);
        }

        public async Task<IEnumerable<data.Ahorros>> GetAllWithAsync()
        {
            return await new DAL.Ahorros(context).GetAllWithAsync();
        }

        public async Task<data.Ahorros> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Ahorros(context).GetOneByIdWithAsync(id);
        }

        public data.Ahorros GetOneById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
