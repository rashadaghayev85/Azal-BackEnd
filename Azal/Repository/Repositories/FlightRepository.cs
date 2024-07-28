﻿using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class FlightRepository : BaseRepository<Flight>, IFLightRepository
    {
        public FlightRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Flight>> GetAllWithIncludeAsync()
        {
            return _context.Flights
               .Include(b => b.Plane)
               .Include(b=>b.ArrivalAirport)
               .Include(b =>b.DepartureAirport)
               .ToList();
        }

        public async Task<Flight> GetByIdWithIncludeAsync(int id)
        {
            return _context.Flights
                .Include(b => b.Plane)
                .Include(bt => bt.ArrivalAirport)
                .Include(bt => bt.DepartureAirport)
                .SingleOrDefault(b => b.Id == id);
        }
        public async Task<SelectList> GetAllSelectedAsync()
        {
            var flights = await _context.Flights.Where(m => !m.SoftDelete).ToListAsync();
            return new SelectList(flights, "Id", "FlightNumber");
        }

        public async Task EditSaveAsync()
        {
            await _context.SaveChangesAsync();  
        }
    }
}
