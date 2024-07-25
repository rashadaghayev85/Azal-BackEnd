using Domain.Models;
using Service.ViewModels.Blogs;
using Service.ViewModels.BlogTranslates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBlogTranslateService
    {
        
        Task<IEnumerable<BlogTranslateVM>> GetAllAsync();
    }
}
