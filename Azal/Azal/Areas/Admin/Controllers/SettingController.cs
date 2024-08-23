using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Helpers.Extensions;
using Service.Services.Interfaces;
using Service.ViewModels.PopularDirections;
using Service.ViewModels.Settings;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public SettingController(ISettingService settingService, 
                                 IWebHostEnvironment env,
                                 IMapper mapper)
        {
            _settingService = settingService;
            _env = env;
            _mapper = mapper;   

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

            var data = _mapper.Map<SettingEditVM>(model);
            return View(data);
           // return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SettingEditVM updatedSetting)
        {

            if (id == null) return BadRequest();
            Setting dbSetting = await _settingService.GetByIdAsync((int)id);
            if (dbSetting is null) return NotFound();

            if (dbSetting.Value.Contains(".svg")||dbSetting.Value.Contains(".png") || dbSetting.Value.Contains(".jpg") || dbSetting.Value.Contains(".jpeg"))
            {
                if (updatedSetting.Image is not null)
                {
                    //string path = Path.Combine(_env.WebRootPath, "assets", "img", fileName);
                    //await request.Image.SaveFileToLocalAsync(path);


                    //string newfileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                    //string newPath = _env.GenerateFilePath("assets/img", newfileName);

                    string oldPath = _env.GenerateFilePath("assets/img", dbSetting.Value);
                    oldPath.DeleteFileFromLocal();

                    //string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "logogallery", dbSetting.Value);
                    //FileHelper.DeleteFile(oldPath);
                   
                    string newfileName = Guid.NewGuid().ToString() + "-" + updatedSetting.Image.FileName;
                    string newPath = _env.GenerateFilePath("assets/img", newfileName);
                    
                    await updatedSetting.Image.SaveFileToLocalAsync(newPath);


                    dbSetting.Value =newfileName;
                        //updatedSetting.Image.CreateFile(_env, "logogallery");
                }
                else
                {
                    Setting newSetting = new()
                    {
                        Value = dbSetting.Value
                    };
                }
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
