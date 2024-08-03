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
    public class SettingsRepository : ISettingsRepository
    {
        private readonly AppDbContext _context;
        public SettingsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task EditSaveAsync()
        {
            await _context.SaveChangesAsync();  
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();    //ToDictionaryAsync(m => m.Key, m => m.Value);

        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(m => m.Id == id);

            if (setting == null)
            {
                return null;
            }

    //        var dictionary = new Dictionary<string, string>
    //{
    //    { "Id", setting.Id.ToString() },
    //    { "Name", setting.Key },
    //    { "Value", setting.Value }

    //};

            return setting;
        }

        public Task<Dictionary<string, string>> GetByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
