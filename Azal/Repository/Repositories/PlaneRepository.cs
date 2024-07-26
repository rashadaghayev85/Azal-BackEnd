using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PlaneRepository : BaseRepository<Plane>, IPlaneRepository
    {
        public PlaneRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var planes = await _context.Planes.Where(m => !m.SoftDelete).ToListAsync();
            return new SelectList(planes, "Id", "Model");
        }
        public async Task<IEnumerable<Plane>> GetAllWithIncludeAsync()
        {
            return _context.Planes
               .Include(b => b.Flights)
               .ToList();
        }

        public async Task<Plane> GetByIdWithIncludeAsync(int id)
        {
            return _context.Planes
                .Include(b => b.Flights)
                .SingleOrDefault(b => b.Id == id);
        }
    }
}
