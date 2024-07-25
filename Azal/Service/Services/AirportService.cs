using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;
using Service.ViewModels.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepo;

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;



        public AirportService(IMapper mapper,
                           IAirportRepository airportRepo,
                           AppDbContext context)

        {
            _airportRepo = airportRepo;
            _mapper = mapper;
            _context = context;

        }
        public async Task CreateAsync(AirportCreateVM model)
        {
            var language = await _context.Languages.SingleOrDefaultAsync(l => l.Id == model.LanguageId);
            if (language == null) return;

            var airport = new Airport
            {
                AirportTranslates = new List<AirportTranslate>
                {
                      new AirportTranslate
                    {
                        
                        Location = model.Location,
                        Language=language
                    }

                }
            };
          

            await _airportRepo.CreateAsync(_mapper.Map<Airport>(airport));
        }

        public async Task DeleteAsync(int id)
        {
            var airport = await GetByIdAsync(id);
            if (airport != null)
            {
                await _airportRepo.DeleteAsync(airport);
            }
        }

        public async Task EditAsync(int id, AirportEditVM model)
        {
            var airport = await _airportRepo.GetByIdWithIncludeAsync(id);
            if (airport == null) return;

            var airportTranslation = airport.AirportTranslates.SingleOrDefault(bt => bt.Language.Culture == model.Culture);
            if (airportTranslation != null)
            {
                airportTranslation.Location = model.Location;
               
                await _airportRepo.EditAsync(airport);
            }
        }

        public async Task EditSaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AirportVM>> GetAllAsync()
        {
            var data = await _airportRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<AirportVM>>(data);
        }

        public async Task<Airport> GetByIdAsync(int id)
        {
            var airport = await _airportRepo.GetByIdAsync(id);

            return _mapper.Map<Airport>(airport);
        }
    }
}
