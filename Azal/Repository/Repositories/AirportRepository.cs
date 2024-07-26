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
    public class AirportRepository : BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Airport>> GetAllWithIncludeAsync()
        {
            return _context.Airports
               .Include(b => b.AirportTranslates)
               .ThenInclude(bt => bt.Language)
               .ToList();
        }

        public async Task<Airport> GetByIdWithIncludeAsync(int id)
        {
            return _context.Airports
                .Include(b => b.AirportTranslates)
                .ThenInclude(bt => bt.Language)
                .SingleOrDefault(b => b.Id == id);
        }
        public async Task<SelectList> GetAllSelectedAsync()
        {
            var airports = await _context.AirportTranslates.Where(m => !m.SoftDelete && m.Language.Culture=="en").ToListAsync();
            return new SelectList(airports, "AirportId", "Location");
        }
    }
}
