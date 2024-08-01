﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IPopularDirectionRepository : IBaseRepository<PopularDirection>
    {
        Task<PopularDirection> GetByIdWithIncludeAsync(int id);
        Task<IEnumerable<PopularDirection>> GetAllWithIncludeAsync();
        
    }
}
