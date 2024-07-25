using Domain.Models;
using Microsoft.AspNetCore.Http;
using Service.ViewModels.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> GetByIdAsync(int blogId);
        Task<IEnumerable<BlogVM>> GetAllAsync();
        //Task CreateAsync(string name, string description, string culture);
        Task CreateAsync(BlogCreateVM model);
        Task EditAsync(int id, BlogEditVM model);
        Task EditSaveAsync();
        Task DeleteAsync(int id);
        
    }
}
