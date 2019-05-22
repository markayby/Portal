using System;
using System.Diagnostics;
using Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Portal.Controllers
{
    public class HomeController : BaseContoller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }
        
        [Authorize(Roles = "Admin, Employee, Head")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error(int code)
        {
            string specificErrorMessage;
            switch (code)
            {
                case 400:
                    specificErrorMessage = _localizer["HttpError400Msg"];
                    break;
                case 401:
                    specificErrorMessage = _localizer["HttpError401Msg"];
                    break;
                case 403:
                    specificErrorMessage = _localizer["HttpError403Msg"];
                    break;
                case 404:
                    specificErrorMessage = _localizer["HttpError404Msg"];
                    break;
                case 500:
                    specificErrorMessage = _localizer["HttpError500Msg"];
                    break;
                default:
                    specificErrorMessage = string.Format(_localizer["HttpErrorDefaultMsg"], code);
                    break;
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, HttpCode = code, MessageForClient = specificErrorMessage});
        }
        
        [AllowAnonymous]
        public IActionResult AuthError(string returnUrl)
        {
            return RedirectToAction("Error", "Home", new { code = 403});
        }
        
        [AllowAnonymous]
        public IActionResult ServerError(string returnUrl)
        {
            return RedirectToAction("Error", "Home", new { code = 500});
        }
    }
}
