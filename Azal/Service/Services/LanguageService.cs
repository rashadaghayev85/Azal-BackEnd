using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;
using Service.ViewModels.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LanguageVM>> GetAllAsync()
        {
            var data = await _languageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LanguageVM>>(data);
            
        }

        public async Task<LanguageVM> GetByIdAsync(int id)
        {
            return _mapper.Map<LanguageVM>(await _languageRepository.GetByIdAsync(id));
            
        }

        public async Task CreateAsync(LanguageCreateVM model)
        {
            await _languageRepository.CreateAsync(_mapper.Map<Language>(model));
           
        }

        public async Task EditAsync(int id,LanguageEditVM model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _languageRepository.GetByIdAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _languageRepository.EditAsync(editData);
           
        }

        public async Task DeleteAsync(int id)
        {
            await _languageRepository.DeleteAsync(id);
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            return await _languageRepository.GetAllSelectedAsync();  
        }
    }
}
