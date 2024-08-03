using Domain.Models;
using Service.ViewModels.PopularDirections;
using Service.ViewModels.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IPopularDirectionService
    {
        Task<PopularDirection> GetByIdAsync(int blogId);
        Task<IEnumerable<PopularDirectionVM>> GetAllAsync();

       
        Task CreateAsync(PopularDirectionCreateVM model);
        Task EditAsync(int id, PopularDirectionEditVM model);
        Task EditSaveAsync();
        Task DeleteAsync(int id);
    }
}
