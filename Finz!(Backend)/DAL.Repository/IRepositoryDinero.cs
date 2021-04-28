using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryDinero: IRepository<data.Dinero>
    {
        Task<IEnumerable<data.Dinero>> GetAllWithAsAsync();

        Task<data.Dinero> GetByOneWithAsAsync(int id);

    }
}
