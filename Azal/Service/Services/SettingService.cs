using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingsRepository _settingsRepo;
        public SettingService(ISettingsRepository settingsRepo)
        {
            _settingsRepo = settingsRepo;
        }

        public async Task EditSaveAsync()
        {
            await _settingsRepo.EditSaveAsync();
        }

        public async Task<List<Setting>> GetAllAsync()
        {
          return await _settingsRepo.GetAllAsync(); 
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return await _settingsRepo.GetByIdAsync(id);
        }
    }
}
