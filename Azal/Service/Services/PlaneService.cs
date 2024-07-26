using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PlaneService :IPlaneService
    {
        private readonly IPlaneRepository _planeRepo;
        private readonly IMapper _mapper;

        public PlaneService(IPlaneRepository planeRepo, IMapper mapper)
        {
            _planeRepo = planeRepo;
            _mapper = mapper;
        }
        public async Task<SelectList> GetAllSelectedAsync()
        {
            return await _planeRepo.GetAllSelectedAsync();
        }

    }
}
