using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : BaseContoller
    {
        public EmployeesController()
        {
            
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}