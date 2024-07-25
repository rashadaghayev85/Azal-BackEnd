using Domain.Models;
using Service.ViewModels.Airports;
using Service.ViewModels.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAirportService
    {
        Task<Airport> GetByIdAsync(int id);
        Task<IEnumerable<AirportVM>> GetAllAsync();
        //Task CreateAsync(string name, string description, string culture);
        Task CreateAsync(AirportCreateVM model);
        Task EditAsync(int id, AirportEditVM model);
        Task EditSaveAsync();
        Task DeleteAsync(int id);
    }
}
