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
    public class HeadsController : BaseContoller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IStringLocalizer<HeadsController> _localizer;

        public HeadsController(ApplicationDbContext applicationDbContext, IStringLocalizer<HeadsController> localizer)
        {
            _applicationDbContext = applicationDbContext;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var heads = await _applicationDbContext.Heads.ToListAsync();

            var result = heads.Select(s => new HeadViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
            });

            return View(result.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new HeadViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HeadViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var head = await _applicationDbContext.Heads.FirstOrDefaultAsync(s => s.Email == viewModel.Email);

                if (head != null)
                {
                    ModelState.AddModelError("", _localizer["HeadExists"]);
                }
                else
                {
                    await _applicationDbContext.Heads
                        .AddAsync(new Head
                        {
                            Email = viewModel.Email,
                            Surname = viewModel.Surname,
                            Name = viewModel.Name,
                        });
                    await _applicationDbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var head = await _applicationDbContext.Heads
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            if (head == null)
            {
                return NotFound();
            }

            var viewModel = new HeadViewModel
            {
                Id = head.Id,
                Name = head.Name,
                Email = head.Email,
                Surname = head.Surname,
            };

            return View("Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HeadViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var head = await _applicationDbContext.Heads
                    .FirstOrDefaultAsync(f => f.Id == viewModel.Id);

                if (head == null)
                {
                    return NotFound();
                }

                head.Email = viewModel.Email;
                head.Name = viewModel.Name;
                head.Surname = viewModel.Surname;
                await _applicationDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Edit", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var head = await _applicationDbContext.Heads
                .FirstOrDefaultAsync(f => f.Id == id);

            if (head == null)
            {
                return NotFound();
            }

            _applicationDbContext.Heads.Remove(head);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}