using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Azal.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        
        private readonly ISettingService _settingService;
        public FooterViewComponent(ISettingService settingService)
        {
          
            _settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var datas = new FooterVMVC
            {
               
                Settings = await _settingService.GetAllAsync(),
            };

            return View(datas);
        }
    }
    public class FooterVMVC
    {
        public List<Setting> Settings { get; set; }
    }
}
