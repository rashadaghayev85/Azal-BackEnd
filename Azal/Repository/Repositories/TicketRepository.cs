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
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context)
        {

        }
       
        public async Task<IEnumerable<Ticket>> GetAllWithIncludeAsync()
        {
            return _context.Tickets
              .Include(b => b.Flight)
              .ToList();
        }

        public async Task<Ticket> GetByIdWithIncludeAsync(int id)
        {
            return _context.Tickets
                .Include(b => b.Flight)
                .SingleOrDefault(b => b.Id == id);
        }
    }
}
