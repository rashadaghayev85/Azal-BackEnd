using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BlogTranslateRepository : BaseRepository<BlogTranslate>, IBlogTranslateRepository
    {
        public BlogTranslateRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BlogTranslateRepository>>GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<BlogTranslateRepository> IBlogTranslateRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
