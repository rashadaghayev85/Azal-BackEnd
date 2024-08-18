using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task<SelectList> GetAllSelectedAsync();
        Task EditSaveAsync();
        
    }
}
