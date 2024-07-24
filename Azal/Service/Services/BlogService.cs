using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                        Title = model.Name,
                        Description = model.Description,
                        Language = language
                    }
                }
            };
            blog.Image = model.Image.FileName;

            await _blogRepo.CreateAsync(_mapper.Map<Blog>(blog));
            //await _blogRepo.CreateAsync(blog);



        }

        public async Task DeleteAsync(int blogId)
        {
            await _blogRepo.DeleteAsync(blogId);
        }

        public async Task EditAsync(int blogId, string newName, string newDescription, string culture)
        {
            var blog = await _blogRepo.GetByIdAsync(blogId);
            if (blog == null) return;

            var blogTranslation = blog.BlogTranslates.SingleOrDefault(bt => bt.Language.Culture == culture);
            if (blogTranslation != null)
            {
                blogTranslation.Title = newName;
                blogTranslation.Description = newDescription;
                await _blogRepo.EditAsync(blog);
            }
        }

        public async Task<IEnumerable<BlogVM>> GetAllAsync()
        {
            var data = await _blogRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogVM>>(data);
            //return await _blogRepo.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int blogId, string culture)
        {
            var blog =await _blogRepo.GetByIdAsync(blogId);
            return blog?.BlogTranslates.Any(bt => bt.Language.Culture == culture) == true ? blog : null;
        }
    }
}
