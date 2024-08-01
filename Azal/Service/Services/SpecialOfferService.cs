using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;
using Service.ViewModels.SpecialOffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SpecialOfferService : ISpecialOffersService
    {
        private readonly ISpecialOffersRepository _specialOffersRepo;
        private readonly ILanguageRepository _languageRepo;
        private readonly IMapper _mapper;

        public SpecialOfferService(ISpecialOffersRepository specialOffersRepo, IMapper mapper, ILanguageRepository languageRepo)
        {
            _specialOffersRepo = specialOffersRepo;
            _mapper = mapper;
            _languageRepo = languageRepo;
        }
        public async  Task CreateAsync(SpecialOfferCreateVM model)
        {
            
             var language =await _languageRepo.GetByIdAsync(model.LanguageId);
            if (language == null) return;
           
            var specialOffer = new SpecialOffer
            {
                SpecialOffersTransLates = new List<SpecialOffersTransLate>
                {
                      new SpecialOffersTransLate
                    {
                        Name = model.Name,
                        Title = model.Title,
                        Description = model.Description,
                        Language=language 
                    }
                      
                }
            };
            specialOffer.Image = model.Image.FileName;

            await _specialOffersRepo.CreateAsync(_mapper.Map<SpecialOffer>(specialOffer));
            
          
          //  var language = await _context.Languages.SingleOrDefaultAsync(l => l.Id == model.LanguageId);


        }

        public async Task DeleteAsync(int id)
        {
            var specialOffer = await GetByIdAsync(id);
            if (specialOffer != null)
            {
                await _specialOffersRepo.DeleteAsync(specialOffer);
            }
        }

        public async Task EditAsync(int id, SpecialOfferEditVM model)
        {
            var specialOffer = await _specialOffersRepo.GetByIdWithIncludeAsync(id);
            if (specialOffer == null) return;

            var SpecialOffersTranslation = specialOffer.SpecialOffersTransLates.SingleOrDefault(bt => bt.Language.Culture == model.Culture);
            if (SpecialOffersTranslation != null)
            {
                SpecialOffersTranslation.Name = model.Name;
                SpecialOffersTranslation.Title = model.Title;
                SpecialOffersTranslation.Description = model.Description;
                await _specialOffersRepo.EditAsync(specialOffer);
            }
        }

        public async Task EditSaveAsync()
        {
            await _specialOffersRepo.EditSaveAsync();
        }

        public async Task<IEnumerable<SpecialOfferVM>> GetAllAsync()
        {
            var data = await _specialOffersRepo.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<SpecialOfferVM>>(data);
        }

        public async Task<SpecialOffer> GetByIdAsync(int blogId)
        {
            var data = await _specialOffersRepo.GetByIdWithIncludeAsync(blogId);

            return _mapper.Map<SpecialOffer>(data);
        }
    }
}
