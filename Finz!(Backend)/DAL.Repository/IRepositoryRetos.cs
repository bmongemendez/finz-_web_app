using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryRetos : IRepository<data.Retos>
    {
        Task<IEnumerable<data.Retos>> GetAllWithAsAsync();

        Task<data.Retos> GetByOneWithAsAsync(int id);
    }
}
