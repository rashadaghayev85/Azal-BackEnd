using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol.Plugins;
using Service.Services.Interfaces;
using Service.ViewModels;

namespace Azal.Controllers
{
    public class WriteUsController : Controller
	{
		private readonly IContactService _contactService;
		private readonly UserManager<AppUser> _userManager;
		private readonly ISettingService _settingService;

		public WriteUsController(IContactService contactService, IHttpContextAccessor accessor,
											  UserManager<AppUser> userManager, ISettingService settingService)
		{
			_contactService = contactService;
			_userManager = userManager;
			_settingService = settingService;
		}
		public async Task<IActionResult> Index()
        {
			AppUser user = new();
			if (User.Identity.Name is not null)
			{
				user = await _userManager.FindByNameAsync(User.Identity.Name);

			}
			ContactVM model = new()
			{
				//UserName = user.Name,
				//Surname=user.Surname,
				Email = user.Email,
			};
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> PostComment(ContactVM request)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction(nameof(Index),request);
			}
			Contact contact = new()
			{
				Message = request.Message,

				Subject = request.Subject,
				Email = request.Email
			};
			
			await _contactService.CreateAsync(contact);
			return Redirect("/");
		}
	}
}
