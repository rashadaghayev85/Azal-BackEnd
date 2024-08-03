using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services.Interfaces;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            var datas = await _settingService.GetAllAsync();

            return View(datas);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Setting Setting = await _settingService.GetByIdAsync((int)id);
            Setting model = new()
            {
                Value = Setting.Value,
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Setting updatedSetting)
        {

            if (id == null) return BadRequest();
            Setting dbSetting = await _settingService.GetByIdAsync((int)id);
            if (dbSetting is null) return NotFound();

            if (dbSetting.Value.Contains(".png") || dbSetting.Value.Contains(".jpg") || dbSetting.Value.Contains(".jpeg"))
            {
                //if (updatedSetting.LogoPhoto is not null)
                //{


                //    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "logogallery", dbSetting.Value);
                //    FileHelper.DeleteFile(oldPath);
                //    dbSetting.Value = updatedSetting.LogoPhoto.CreateFile(_env, "logogallery");
                //}
                //else
                //{
                //    Setting newSetting = new()
                //    {
                //        Value = dbSetting.Value
                //    };
                //}
            }
            else
            {
                if (dbSetting.Value.Trim().ToLower() == updatedSetting.Value.Trim().ToLower())
                {
                    return RedirectToAction(nameof(Index));
                }
                dbSetting.Value = updatedSetting.Value;
            }
            await _settingService.EditSaveAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
