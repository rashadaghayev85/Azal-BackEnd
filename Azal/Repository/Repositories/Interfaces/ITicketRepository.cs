using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Task<Ticket> GetByIdWithIncludeAsync(int id);
        Task<IEnumerable<Ticket>> GetAllWithIncludeAsync();
    }
}
