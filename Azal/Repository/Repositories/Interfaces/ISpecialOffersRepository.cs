using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ISpecialOffersRepository : IBaseRepository<SpecialOffer>
    {
        Task<SpecialOffer> GetByIdWithIncludeAsync(int id);
        Task<IEnumerable<SpecialOffer>> GetAllWithIncludeAsync();
        Task EditSaveAsync();
    }
}
