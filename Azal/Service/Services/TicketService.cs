using AutoMapper;
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

        public async Task CreateAsync(TicketCreateVM model,int count)
        {
            if (model == null) throw new ArgumentNullException();
            var flight =await  _flightRepository.GetByIdAsync(model.Flight);
            if (flight.TicketCount!=0)
            {
                string uniqueCode = GenerateUniqueCode();
                string randomWord = GenerateRandomWord(6);

                model.TicketNumber = uniqueCode;
                model.ReservationNumber = randomWord;
            await _ticketRepo.CreateAsync(_mapper.Map<Ticket>(model));
            flight.TicketCount-=count;
            await _flightRepository.EditSaveAsync();
                return;
            }
            else
            {
               
            }

        }
        private string GenerateUniqueCode()
        {
            Random random = new Random();
            string code = string.Empty;

            for (int i = 0; i < 13; i++)
            {
                code += random.Next(0, 10); // 0-9 arası təsadüfi rəqəm əlavə edir
            }

            return code;
        }

        private string GenerateRandomWord(int length)
        {
            Random random = new Random();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Böyük hərflərdən ibarət dəst
            char[] word = new char[length];

            for (int i = 0; i < length; i++)
            {
                word[i] = letters[random.Next(letters.Length)];
            }

            return new string(word);
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
