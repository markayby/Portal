using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Portal.Entities;
using Portal.ViewModels;

namespace Portal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : BaseContoller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IStringLocalizer<UsersController> _localizer;

        public UsersController(ApplicationDbContext applicationDbContext, IStringLocalizer<UsersController> localizer)
        {
            _applicationDbContext = applicationDbContext;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = User.Identity.Name;
            
            var requests  = await _applicationDbContext.Requests
                .AsNoTracking()
                .Where(i => i.Employee.Login.Equals(currentUser))
                .Include(i => i.Heads)
                .ToListAsync();

            var result = requests.Select(s => new HistoryRequestViewModel
            {
                Id = s.Id,
                Employee = $"{s.Employee.Name} {s.Employee.Name}",
                Completed = s.Completed? "yes": "no",
                Status = s.Status.ToString(),
                Type = s.Type.ToString(),
                DateFrom = s.DateFrom,
                DateTo = s.DateTo,
                Heads = string.Join(',' ,s.Heads),
            });

            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new HeadViewModel();
            return View(model);
        }


        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}