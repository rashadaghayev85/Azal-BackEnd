using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IPlaneRepository : IBaseRepository<Plane>
    {
        Task<SelectList> GetAllSelectedAsync();
        Task<Plane> GetByIdWithIncludeAsync(int id);
        Task<IEnumerable<Plane>> GetAllWithIncludeAsync();
    }
}
