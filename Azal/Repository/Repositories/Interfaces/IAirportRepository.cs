using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IAirportRepository : IBaseRepository<Airport>
    {
        Task<Airport> GetByIdWithIncludeAsync(int id);
        Task<IEnumerable<Airport>> GetAllWithIncludeAsync();
        Task<SelectList> GetAllSelectedAsync();
    }
}
