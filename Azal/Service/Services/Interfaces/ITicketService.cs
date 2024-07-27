
using Domain.Models;
using Service.ViewModels.Planes;
using Service.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> GetByIdAsync(int id);
        Task<IEnumerable<TicketVM>> GetAllAsync();
        Task CreateAsync(TicketCreateVM model);
       /// Task EditAsync(int id, PlaneEditVM model);
       // Task DeleteAsync(int id);
       // Task EditSaveAsync();
    }
}
