﻿using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Planes;
using Service.ViewModels.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TicketService :ITicketService
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly IFLightRepository _flightRepository;
        private readonly IMapper _mapper;
      

        public TicketService(ITicketRepository ticketRepo, IMapper mapper, IFLightRepository flightRepository)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task CreateAsync(TicketCreateVM model)
        {
            if (model == null) throw new ArgumentNullException();
            var flight =await  _flightRepository.GetByIdAsync(model.Flight);
            if (flight.TicketCount!=0)
            {
            await _ticketRepo.CreateAsync(_mapper.Map<Ticket>(model));
            flight.TicketCount--;
            await _flightRepository.EditSaveAsync();

            }
            else
            {
               
            }

        }

        public async Task<IEnumerable<TicketVM>> GetAllAsync()
        {
            var data = await _ticketRepo.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<TicketVM>>(data);
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var ticket = await _ticketRepo.GetByIdWithIncludeAsync(id);

            return _mapper.Map<Ticket>(ticket);
        }
    }
}
