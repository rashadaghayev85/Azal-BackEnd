using Domain.Models;
using Service.ViewModels.Blogs;
using Service.ViewModels.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISpecialOffersService
    {
        Task<SpecialOffer> GetByIdAsync(int blogId);
        Task<IEnumerable<SpecialOfferVM>> GetAllAsync();
        Task CreateAsync(SpecialOfferCreateVM model);
        Task EditAsync(int id, SpecialOfferEditVM model);
        Task EditSaveAsync();
        Task DeleteAsync(int id);
    }
}
