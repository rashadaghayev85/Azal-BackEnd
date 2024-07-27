using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;
using Service.ViewModels.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FlightService :IFlightService
    {
        private readonly IFLightRepository _flightRepo;

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;



        public FlightService(IMapper mapper,
                           IFLightRepository flightRepo,
                           AppDbContext context)

        {
           _flightRepo = flightRepo;
            _mapper = mapper;
            _context = context;

        }

        public async Task CreateAsync(FlightCreateVM model)
        {
            if (model == null) throw new ArgumentNullException();

            await _flightRepo.CreateAsync(_mapper.Map<Flight>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
            {
             
                throw new ArgumentNullException();
            }
            var data = await _flightRepo.GetByIdWithIncludeAsync((int)id);
            await _flightRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, FlightEditVM model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await  _flightRepo.GetByIdWithIncludeAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _flightRepo.EditAsync(editData);
        }

        public async Task EditSaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FlightVM>> GetAllAsync()
        {
            var data = await _flightRepo.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<FlightVM>>(data);
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            var flight = await _flightRepo.GetByIdWithIncludeAsync(id);

            return _mapper.Map<Flight>(flight);
        }
        public async Task<SelectList> GetAllSelectedAsync()
        {
            return await _flightRepo.GetAllSelectedAsync();
        }
    }
}
