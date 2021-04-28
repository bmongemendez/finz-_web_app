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
    public class Gastos : ICrud<data.Gastos>
    {

        private SolutionDbContext context = null;
        public Gastos(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Gastos t)
        {
            new DAL.Gastos(context).Delete(t);
        }

        public IEnumerable<data.Gastos> GetAll()
        {
            return new DAL.Gastos(context).GetAll();
        }

        public data.Gastos GetOneById(int id)
        {
            return new DAL.Gastos(context).GetOneById(id);
        }

        public void Insert(data.Gastos t)
        {
            new DAL.Gastos(context).Insert(t);
        }

        public void Update(data.Gastos t)
        {
            new DAL.Gastos(context).Update(t);
        }

        public async Task<IEnumerable<data.Gastos>> GetAllWithAsync()
        {
            return await new DAL.Gastos(context).GetAllWithAsync();
        }

        public async Task<data.Gastos> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Gastos(context).GetOneByIdWithAsync(id);
        }

        public data.Gastos GetOneById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
