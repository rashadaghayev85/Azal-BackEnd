using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.ViewModels.Users;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            List<UserRoleVM> userWithRoles = new();
            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);
                var userRoles = String.Join(",", roles.ToArray());
                userWithRoles.Add(new UserRoleVM
                {
                    Name = item.Name,
                    Email = item.Email,
                    Surname = item.Surname,
                    Roles = userRoles
                });
            }
            return View(userWithRoles);
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AddRole()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            ViewBag.users = new SelectList(users, "Id", "Email");
            ViewBag.roles = new SelectList(roles, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AddRole(UserAddRoleVM request)
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            ViewBag.users = new SelectList(users, "Id", "UserName");
            ViewBag.roles = new SelectList(roles, "Id", "Name");
            var user = await _userManager.FindByIdAsync(request.UsernameId);
            var role = await _roleManager.FindByIdAsync(request.RoleId);
            var existRole = await _userManager.IsInRoleAsync(user, role.Name);
            if (existRole)
            {
                ModelState.AddModelError(string.Empty, "This role is exist at User");
                return View();
            }
            await _userManager.AddToRoleAsync(user, role.Name);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> RemoveRole()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            ViewBag.users = new SelectList(users, "Id", "Email");
            ViewBag.roles = new SelectList(roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRole(UserRemoveRoleVM request)
        {
            if (string.IsNullOrEmpty(request.UsernameId) || string.IsNullOrEmpty(request.RoleId))
            {
                return BadRequest("Invalid userId or roleId");
            }

            var user = await _userManager.FindByIdAsync(request.UsernameId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var role = await _roleManager.FindByIdAsync(request.RoleId);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User"); // "User" əvəzinə istifadəçi controllerin adı ilə əvəz edin
            }

            return BadRequest("Failed to remove role");
        }
    }
}
