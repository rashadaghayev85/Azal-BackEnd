using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        Task EditSaveAsync();
        Task<IEnumerable<Banner>> GetAllPaginateAsync(int page, int take);
        Task<IEnumerable<Banner>> GetMappedDatas(IEnumerable<Banner> banners);
        Task<int> GetCountAsync();

    }
}
