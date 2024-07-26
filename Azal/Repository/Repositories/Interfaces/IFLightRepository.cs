using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IFLightRepository : IBaseRepository<Flight>
    {
        Task<Flight> GetByIdWithIncludeAsync(int id);
        Task<IEnumerable<Flight>> GetAllWithIncludeAsync();
    }
}
