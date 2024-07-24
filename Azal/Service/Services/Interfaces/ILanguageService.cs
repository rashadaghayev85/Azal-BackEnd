using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.ViewModels.Languages;


namespace Service.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageVM>> GetAllAsync();
        Task<LanguageVM> GetByIdAsync(int id);
        Task CreateAsync(LanguageCreateVM model);
        Task EditAsync(int id,LanguageEditVM model);
        Task DeleteAsync(int id);
        Task<SelectList> GetAllSelectedAsync();
    }
}
