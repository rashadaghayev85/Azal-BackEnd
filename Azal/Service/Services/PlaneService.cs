using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Flights;
using Service.ViewModels.Planes;
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

        public async Task CreateAsync(PlaneCreateVM model)
        {
            if (model == null) throw new ArgumentNullException();

            await _planeRepo.CreateAsync(_mapper.Map<Plane>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
            {

                throw new ArgumentNullException();
            }
            var data = await _planeRepo.GetByIdWithIncludeAsync((int)id);
            await _planeRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, PlaneEditVM model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _planeRepo.GetByIdWithIncludeAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _planeRepo.EditAsync(editData);
        }

        

        public async Task<IEnumerable<PlaneVM>> GetAllAsync()
        {
            var data = await _planeRepo.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<PlaneVM>>(data);
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            return await _planeRepo.GetAllSelectedAsync();
        }

        public async Task<Plane> GetByIdAsync(int id)
        {
            var plane = await _planeRepo.GetByIdWithIncludeAsync(id);

            return _mapper.Map<Plane>(plane);
        }
    }
}
