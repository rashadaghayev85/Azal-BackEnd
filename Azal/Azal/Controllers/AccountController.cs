using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Service.Helpers.Enums;
using Service.ViewModels.Accounts;


using Service.Services;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;


namespace Azal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailService _emailService;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 EmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new()
            {
                Name = request.Name,
                UserName=request.Email,
                Email = request.Email,
                Surname = request.Surname,
                FatherName=request.FatherName,
                DocumentExpiryDate = request.DocumentExpiryDate,
                DocumentNumber = request.DocumentNumber,
                BirthDay=request.BirthDay,
                CountryCode=request.CountryCode,
                Country=request.Country,
                Address=request.Address,    
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                //return View();
            }

            await _userManager.AddToRoleAsync(user, nameof(Roles.Member));
            //   await _signInManager.SignInAsync(user, isPersistent: false);

            // return RedirectToAction("Index","Home");

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var url = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, token }, Request.Scheme, Request.Host.ToString());


            // create email message
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse("rashadra@code.edu.az"));
            email.To.Add(MailboxAddress.Parse(user.Email));
            email.Subject = "Azal Confirmation";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<a href='{url}'>Click here for confirmation</a>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("rashadra@code.edu.az", "wugf kjzi zhge tzmb");
            smtp.Send(email);
            smtp.Disconnect(true);


            return RedirectToAction(nameof(VerifyEmail));

        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.ConfirmEmailAsync(user, token);
            return RedirectToAction(nameof(SignIn));
        }


        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var existUser = await _userManager.FindByEmailAsync(request.Email);
            if (existUser == null)
            {
                existUser = await _userManager.FindByNameAsync(request.Email);
            }

            if (existUser == null)
            {
                ModelState.AddModelError(string.Empty, "Login failed");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(existUser, request.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login failed");
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            return Ok();
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu email üçün istifadəçi tapılmadı.");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

            await _emailService.SendEmailAsync(model.Email, "Şifrəni Sıfırla", $"Zəhmət olmasa şifrənizi sıfırlamaq üçün <a href='{callbackUrl}'>buraya</a> klikləyin.");

            ViewBag.Message = "Şifrə sıfırlama linki email ünvanınıza göndərildi.";
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string userId)
        {
            if (token == null || userId == null)
                return BadRequest();

            var model = new ResetPasswordVM { Token = token, UserId = userId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "İstifadəçi tapılmadı.");
                return View();
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(SignIn));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction(nameof(SignIn));
        }
    }
}
