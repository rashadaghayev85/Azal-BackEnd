﻿using Domain.Models;
using Service.ViewModels.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBannerService
    {
        Task<IEnumerable<BannerVM>> GetAllAsync();
        Task CreateAsync(BannerCreateVM model);
        Task<Banner> GetByIdAsync(int? id);
        Task EditAsync(int id,BannerEditVM model);
        Task EditAsync();
        Task DeleteAsync(int id);
    }
}
