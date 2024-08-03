using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllAsync();
        Task<Setting> GetByIdAsync(int id);

        Task EditSaveAsync();

    }
}
