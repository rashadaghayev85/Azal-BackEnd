using Domain.Models;
using Service.ViewModels.Airports;
using Service.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IFlightService
    {
        Task<Flight> GetByIdAsync(int id);
        Task<IEnumerable<FlightVM>> GetAllAsync();
        //Task CreateAsync(string name, string description, string culture);
        Task CreateAsync(FlightCreateVM model);
        Task EditAsync(int id, FlightEditVM model);
        Task EditSaveAsync();
        Task DeleteAsync(int id);
    }
}
