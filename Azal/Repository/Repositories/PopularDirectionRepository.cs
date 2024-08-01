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
    public class PopularDirectionRepository : BaseRepository<PopularDirection>, IPopularDirectionRepository
    {
        public PopularDirectionRepository(AppDbContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<PopularDirection>> GetAllWithIncludeAsync()
        {
            return _context.PopularDirections
                 .Include(b => b.PopularDirectionTranslates)
                 .ThenInclude(bt => bt.Language)
                 .ToList();
        }

        public async Task<PopularDirection> GetByIdWithIncludeAsync(int id)
        {
            return _context.PopularDirections
                .Include(b => b.PopularDirectionTranslates)
                .ThenInclude(bt => bt.Language)
                .SingleOrDefault(b => b.Id == id);
        }
    }
}
