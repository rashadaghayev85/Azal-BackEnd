using Domain.Models;
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
    public class SpecialOffersRepository : BaseRepository<SpecialOffer>, ISpecialOffersRepository
    {
        public SpecialOffersRepository(AppDbContext context) : base(context)
        {

        }
        public async Task EditSaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpecialOffer>> GetAllWithIncludeAsync()
        {
            return _context.SpecialOffers
                .Include(b => b.SpecialOffersTransLates)
                .ThenInclude(bt => bt.Language)
                .ToList();
        }

        public async Task<SpecialOffer> GetByIdWithIncludeAsync(int id)
        {
            return _context.SpecialOffers
                .Include(b => b.SpecialOffersTransLates)
                .ThenInclude(bt => bt.Language)
                .SingleOrDefault(b => b.Id == id);
        }
    }
}
