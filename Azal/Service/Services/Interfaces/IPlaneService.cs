using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.ViewModels.Flights;
using Service.ViewModels.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IPlaneService
    {
        Task<SelectList> GetAllSelectedAsync();
        Task<Plane> GetByIdAsync(int id);
        Task<IEnumerable<PlaneVM>> GetAllAsync();
        //Task CreateAsync(string name, string description, string culture);
        Task CreateAsync(PlaneCreateVM model);
        Task EditAsync(int id, PlaneEditVM model);
        Task DeleteAsync(int id);
    }
}
