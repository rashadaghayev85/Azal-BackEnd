using Domain.Models;
using Service.ViewModels.Passengers;
using Service.ViewModels.Planes;
using Service.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IPassengerService
    {
        Task<Passenger> GetByIdAsync(int id);
        Task<IEnumerable<PassengerVM>> GetAllAsync();
        //Task CreateAsync(string name, string description, string culture);
        Task CreateAsync(PassengerCreateVM model);
        Task EditAsync(int id, PassengerEditVM model);
        Task DeleteAsync(int id);
        Task EditSaveAsync();
    }
}
