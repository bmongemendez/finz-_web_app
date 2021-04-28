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
    public class GastosFijos : ICrud<data.GastosFijos>
    {

        private SolutionDbContext context = null;
        public GastosFijos(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.GastosFijos t)
        {
            new DAL.GastosFijos(context).Delete(t);
        }

        public IEnumerable<data.GastosFijos> GetAll()
        {
            return new DAL.GastosFijos(context).GetAll();
        }

        public data.GastosFijos GetOneById(int id)
        {
            return new DAL.GastosFijos(context).GetOneById(id);
        }

        public void Insert(data.GastosFijos t)
        {
            new DAL.GastosFijos(context).Insert(t);
        }

        public void Update(data.GastosFijos t)
        {
            new DAL.GastosFijos(context).Update(t);
        }

        public async Task<IEnumerable<data.GastosFijos>> GetAllWithAsync()
        {
            return await new DAL.GastosFijos(context).GetAllWithAsync();
        }

        public async Task<data.GastosFijos> GetOneByIdWithAsync(int id)
        {
            return await new DAL.GastosFijos(context).GetOneByIdWithAsync(id);
        }

        public data.GastosFijos GetOneById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
