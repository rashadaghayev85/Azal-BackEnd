using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<Blog> GetByIdAsync(int id);
        Task<IEnumerable<Blog>> GetAllAsync();
        Task CreateAsync(Blog blog);
        Task EditAsync(Blog blog);
        Task EditSaveAsync();
        Task DeleteAsync(Blog blog);
        
    }
}
