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
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext context) : base(context)
        {

        }

        public async Task EditSaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Banner>> GetAllPaginateAsync(int page, int take)
        {
            return await _context.Banners.Where(m => !m.SoftDelete)
                                         .Skip((page - 1) * take)
                                         .Take(take)
                                         .ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Banners.CountAsync();
        }

        public async Task<IEnumerable<Banner>> GetMappedDatas(IEnumerable<Banner> banners)
        {
            return banners.Select(m => new Banner()
            {
                Id = m.Id,
                Image=m.Image,
                IsActive=m.IsActive,
                SoftDelete=m.SoftDelete,
                CreatedDate=m.CreatedDate,
            }); ;
        }
    }
}
