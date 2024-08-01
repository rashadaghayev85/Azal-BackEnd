using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.PopularDirections;
using Service.ViewModels.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PopularDirectionService :IPopularDirectionService
    {
        private readonly IPopularDirectionRepository _popularDirectionRepo;
        private readonly ILanguageRepository _languageRepo;
        private readonly IMapper _mapper;

        public PopularDirectionService(IPopularDirectionRepository popularDirectionRepository,
                                       IMapper mapper,
                                       ILanguageRepository languageRepo)
        {
            _popularDirectionRepo = popularDirectionRepository;
            _mapper = mapper;
            _languageRepo = languageRepo;
        }

        public async Task CreateAsync(PopularDirectionCreateVM model)
        {
            var language = await _languageRepo.GetByIdAsync(model.LanguageId);
            if (language == null) return;

            var popularDirection = new PopularDirection
            {
                PopularDirectionTranslates = new List<PopularDirectionTranslate>
                {
                      new PopularDirectionTranslate
                    {
                        Country = model.Country,
                        City = model.City,
                        Language=language
                    }

                }
            };

            popularDirection.Image = model.Image.FileName;
           popularDirection.Price_usd = model.Price_usd;
            popularDirection.Price_azn=model.Price_azn;

            await _popularDirectionRepo.CreateAsync(_mapper.Map<PopularDirection>(popularDirection));

        }

        public async Task DeleteAsync(int id)
        {
            var popularDirection = await GetByIdAsync(id);
            if (popularDirection != null)
            {
                await _popularDirectionRepo.DeleteAsync(popularDirection);
            }
        }

        public async Task EditAsync(int id, PopularDirectionEditVM model)
        {
            var popularDirection = await _popularDirectionRepo.GetByIdWithIncludeAsync(id);
            if (popularDirection == null) return;

            var popularDirectionTranslation = popularDirection.PopularDirectionTranslates.SingleOrDefault(bt => bt.Language.Culture == model.Culture);
            if (popularDirectionTranslation != null)
            {
                popularDirectionTranslation.City = model.City;
                popularDirectionTranslation.Country = model.Country;
               
            popularDirection.Price_azn = model.Price_azn;
            popularDirection.Price_usd = model.Price_usd;
                await _popularDirectionRepo.EditAsync(popularDirection);
            }

        }

        public async Task EditSaveAsync()
        {
            await _popularDirectionRepo.EditSaveAsync();
        }

        public async Task<IEnumerable<PopularDirectionVM>> GetAllAsync()
        {
            var data = await _popularDirectionRepo.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<PopularDirectionVM>>(data);
        }

        public async Task<PopularDirection> GetByIdAsync(int blogId)
        {
            var data = await _popularDirectionRepo.GetByIdAsync(blogId);

            return _mapper.Map<PopularDirection>(data);
        }
    }
}
