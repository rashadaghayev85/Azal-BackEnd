using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;

namespace Azal.Areas.Admin.ViewComponents
{
   
    public class AdminHeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
       
        private readonly UserManager<AppUser> _userManager;

        public AdminHeaderViewComponent(ISettingService settingService,
                                   IHttpContextAccessor accessor,
                                  
                                  UserManager<AppUser> userManager)
        {
            _settingService = settingService;
          
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            AppUser user = new();
            if (User.Identity.Name is not null)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);

            }

            var settings = await _settingService.GetAllAsync();
            
            AdminHeaderVM response = new()
            {
                Settings = settings,
                
                User = user,
            };
            return await Task.FromResult(View(response));
        }


    }

    public class AdminHeaderVM
    {
        public AppUser User { get; set; }
      
        public List<Setting> Settings { get; set; }
    }
}
