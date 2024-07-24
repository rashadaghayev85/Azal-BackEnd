using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Banners;



namespace Service.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepo;

        private readonly IMapper _mapper;
       

        public BannerService(IMapper mapper,
                           IBannerRepository bannerRepo)

        {
           _bannerRepo = bannerRepo;
            _mapper = mapper;
            
        }

        public async Task CreateAsync(BannerCreateVM model)
        {
            if (model == null) throw new ArgumentNullException();

            await _bannerRepo.CreateAsync(_mapper.Map<Banner>(model));
        }

        public async Task EditAsync(int id, BannerEditVM model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _bannerRepo.GetByIdAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _bannerRepo.EditAsync(editData);
        }

        public async Task EditAsync()
        {
            await _bannerRepo.EditAsync();
        }

        public async Task<IEnumerable<BannerVM>> GetAllAsync()
        {

            var data = await _bannerRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<BannerVM>>(data);
        }

        public async Task<BannerVM> GetByIdAsync(int? id)
        {
            return _mapper.Map<BannerVM>(await _bannerRepo.GetByIdAsync((int)id));
        }
    }
}
