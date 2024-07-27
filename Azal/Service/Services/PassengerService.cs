
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Passengers;
using Service.ViewModels.Planes;
using Service.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepo;
        private readonly IMapper _mapper;

        public PassengerService(IPassengerRepository passengerRepo, IMapper mapper)
        {
           _passengerRepo = passengerRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(PassengerCreateVM model)
        {
            if (model == null) throw new ArgumentNullException();

            await _passengerRepo.CreateAsync(_mapper.Map<Passenger>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
            {

                throw new ArgumentNullException();
            }
            var data = await _passengerRepo.GetByIdAsync((int)id);
            await _passengerRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, PassengerEditVM model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _passengerRepo.GetByIdAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _passengerRepo.EditAsync(editData);
        }

        public async Task EditSaveAsync()
        {
            await _passengerRepo.EditSaveAsync();
        }

        public async Task<IEnumerable<PassengerVM>> GetAllAsync()
        {
            var data = await _passengerRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<PassengerVM>>(data);
        }

        //public async Task<SelectList> GetAllSelectedAsync()
        //{
        //    return await _passengerRepo.GetAllSelectedAsync();
        //}

        public async Task<Passenger> GetByIdAsync(int id)
        {
            var passenger = await _passengerRepo.GetByIdAsync(id);

            return _mapper.Map<Passenger>(passenger);
        }
    }
}
