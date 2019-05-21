using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Portal.ViewModels;
using Portal.Entities;
using CryptoHelper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Portal.Controllers
{
    public class AccountController : BaseContoller
    {
        private ApplicationDbContext db;
        private readonly IStringLocalizer<AccountController> _localizer;

        public AccountController(ApplicationDbContext context, IStringLocalizer<AccountController> localizer)
        {
            db = context;
            _localizer = localizer;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Users");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login);

                if (user != null && Crypto.VerifyHashedPassword(user.Password, model.Password))
                {
                    var userRole = user.Role?.Name;
                    
                    await Authenticate(model.Login, userRole);

                    return ChooseHomePage(userRole);
                }

                ModelState.AddModelError("", _localizer["LoginOrPasswordIsInvalid"]);
            }

            return View(model);
        }

        private async Task Authenticate(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
            };

            if (role != null)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            HttpContext.Session.Clear();
            
            return RedirectToAction("Login", "Account");
        }
        
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = User.Identity.Name;
                var user = db.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(s => s.Login == currentUserName);
                if (user == null)
                {
                    return NotFound();
                }
                
                var userRole = user.Role?.Name;
                
                user.Password = Crypto.HashPassword(viewModel.Password);
                await db.SaveChangesAsync();

                return ChooseHomePage(userRole);
            }

            return View(viewModel);
        }

        private IActionResult ChooseHomePage(string role)
        {
            return string.Equals(role, "Admin") 
                ? RedirectToAction("Index", "Users") 
                :RedirectToAction("Index", "Home");
        }
    }
}