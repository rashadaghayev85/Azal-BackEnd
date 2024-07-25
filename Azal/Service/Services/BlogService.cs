using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;

namespace Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepo;

        private readonly IMapper _mapper;
        private readonly AppDbContext _context;



        public BlogService(IMapper mapper,
                           IBlogRepository blogRepo,
                           AppDbContext context)

        {
            _blogRepo = blogRepo;
            _mapper = mapper;
            _context = context;

        }
        public async Task CreateAsync(BlogCreateVM model)
        {
            var language = await _context.Languages.SingleOrDefaultAsync(l => l.Id == model.LanguageId);
            if (language == null) return;

            var blog = new Blog
            {
                BlogTranslates = new List<BlogTranslate>
                {
                      new BlogTranslate
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Language=language
                    }

                }
            };
            blog.Image = model.Image.FileName;

            await _blogRepo.CreateAsync(_mapper.Map<Blog>(blog));
            //await _blogRepo.CreateAsync(blog);



        }

        public async Task DeleteAsync(int id)
        {
            var blog = await GetByIdAsync(id);
            if (blog != null)
            {
                await _blogRepo.DeleteAsync(blog);
            }
        }

        public async Task EditAsync(int id,BlogEditVM model)
        {
            var blog = await _blogRepo.GetByIdAsync(id);
            if (blog == null) return;

            var blogTranslation = blog.BlogTranslates.SingleOrDefault(bt => bt.Language.Culture == model.Culture);
            if (blogTranslation != null)
            {
                blogTranslation.Name = model.Name;
                blogTranslation.Description = model.Description;
                await _blogRepo.EditAsync(blog);
            }
        }

        public async Task EditSaveAsync()
        {
           await _blogRepo.EditSaveAsync();
        }

        public async Task<IEnumerable<BlogVM>> GetAllAsync()
        {
            var data = await _blogRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogVM>>(data);
            //return await _blogRepo.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int blogId)
        {
            var blog = await _blogRepo.GetByIdAsync(blogId);
            
            return _mapper.Map<Blog>(blog);

           
        }
    }
}
