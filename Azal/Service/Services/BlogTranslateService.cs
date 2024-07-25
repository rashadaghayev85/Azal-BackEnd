using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.BlogTranslates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BlogTranslateService : IBlogTranslateService
    {
        private readonly IBlogTranslateRepository _blogTranslateRepo;

        private readonly IMapper _mapper;


        public BlogTranslateService(IMapper mapper,
                           IBlogTranslateRepository blogTranslateRepo)

        {
           _blogTranslateRepo = blogTranslateRepo;
            _mapper = mapper;

        }
        public async Task<IEnumerable<BlogTranslateVM>> GetAllAsync()
        {
            var data = await _blogTranslateRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogTranslateVM>>(data);
            
        }
    }
}
