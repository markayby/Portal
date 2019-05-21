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
//            var heads = await _applicationDbContext.Heads.ToListAsync();
//
//            var result = heads.Select(s => new HeadViewModel
//            {
//                Id = s.Id,
//                Name = s.Name,
//                Surname = s.Surname,
//                Email = s.Email,
//            });
//
//            return View(result.ToList());
            return View();
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