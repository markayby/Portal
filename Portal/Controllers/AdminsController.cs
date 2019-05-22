using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class AdminsController : BaseContoller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult UsersDetails()
        {
            return View();
        }
    }
}