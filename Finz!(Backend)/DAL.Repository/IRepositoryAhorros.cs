using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryAhorros : IRepository<data.Ahorros>
    {
        Task<IEnumerable<data.Ahorros>> GetAllWithAsAsync();

        Task<data.Ahorros> GetByOneWithAsAsync(int id);

    }
}
