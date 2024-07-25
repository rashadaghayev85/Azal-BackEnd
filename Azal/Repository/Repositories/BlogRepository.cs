using Domain.Models;
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
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {

        }
        public async Task CreateAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Blog blog)
        {
           
                _context.Remove(blog);
                await _context.SaveChangesAsync();
            

           
        }

        public async Task EditAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }

        public async Task EditSaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return _context.Blogs
               .Include(b => b.BlogTranslates)
               .ThenInclude(bt => bt.Language)
               .ToList();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return  _context.Blogs
                .Include(b => b.BlogTranslates)
                .ThenInclude(bt => bt.Language)
                .SingleOrDefault(b => b.Id == id);
        }
    }
}
