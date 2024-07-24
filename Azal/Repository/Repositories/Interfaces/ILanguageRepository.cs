using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language> GetByIdAsync(int id);
        Task CreateAsync(Language language);
        Task EditAsync(Language language);
        Task DeleteAsync(int id);
        Task<SelectList> GetAllSelectedAsync();
    }
}
