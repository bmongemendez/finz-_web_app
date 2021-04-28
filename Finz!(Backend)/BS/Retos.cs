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
    public class Retos : ICrud<data.Retos>
    {

        private SolutionDbContext context = null;
        public Retos(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Retos t)
        {
            new DAL.Retos(context).Delete(t);
        }

        public IEnumerable<data.Retos> GetAll()
        {
            return new DAL.Retos(context).GetAll();
        }

        public data.Retos GetOneById(int id)
        {
            return new DAL.Retos(context).GetOneById(id);
        }

        public void Insert(data.Retos t)
        {
            new DAL.Retos(context).Insert(t);
        }

        public void Update(data.Retos t)
        {
            new DAL.Retos(context).Update(t);
        }

        public async Task<IEnumerable<data.Retos>> GetAllWithAsync()
        {
            return await new DAL.Retos(context).GetAllWithAsync();
        }

        public async Task<data.Retos> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Retos(context).GetOneByIdWithAsync(id);
        }
    }
}
