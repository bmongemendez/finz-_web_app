using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryGastosFijos : IRepository<data.GastosFijos>
    {
        Task<IEnumerable<data.GastosFijos>> GetAllWithAsAsync();

        Task<data.GastosFijos> GetByOneWithAsAsync(int id);
    }
}
