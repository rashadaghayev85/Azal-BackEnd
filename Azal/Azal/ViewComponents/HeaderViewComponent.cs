using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;

namespace Azal.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly IAirportService _airportService;
        private readonly IFlightService _flightService; 
       // private readonly UserManager<AppUser> _userManager;

        public HeaderViewComponent(ISettingService settingService, 
                                   IHttpContextAccessor accessor,
                                   IAirportService airportService,
                                   IFlightService flightService)
                                             // UserManager<AppUser> userManager)
        {
            _settingService = settingService;
            _airportService = airportService;
            _flightService = flightService;
          //  _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            //AppUser user = new();
            //if (User.Identity.Name is not null)
            //{
            //    user = await _userManager.FindByNameAsync(User.Identity.Name);

            //}

            var settings = await _settingService.GetAllAsync();
            var airports= await _airportService.GetAllAsync();  
            HeaderVM response = new()
            {
                Settings = settings,
                Airports=airports
                //User = user,
            };
            return await Task.FromResult(View(response));
        }
       

    }
    
    public class HeaderVM
    {
        // public AppUser User { get; set; }
        public IEnumerable<AirportVM> Airports { get; set; }
        public List<Setting> Settings { get; set; }
    }
}
