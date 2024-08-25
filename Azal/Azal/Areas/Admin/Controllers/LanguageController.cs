using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Flights;
using Service.ViewModels.Languages;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService,
                                  IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var languages = await _languageService.GetAllAsync();
            return View(languages);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageCreateVM request)
        {
            if (ModelState.IsValid)
            {
                await _languageService.CreateAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var language = await _languageService.GetByIdAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<LanguageEditVM>(language);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LanguageEditVM request)
        {
           
            if (ModelState.IsValid)
            {
                await _languageService.EditAsync(id,request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var language = await _languageService.GetByIdAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _languageService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
