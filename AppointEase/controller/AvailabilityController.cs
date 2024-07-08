using AppointEase.Data;
using AppointEase.Model;
using AppointEase.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppointEase.controller
{
    [Authorize]
    public class AvailabilityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AvailabilityController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var availabilities = await _context.Availabilities
                                               .Where(a => a.UserId == user.Id)
                                               .ToListAsync();
            return View(availabilities);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AvailabilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var availability = new Availability
                {
                    UserId = user.Id,
                    DayOfWeek = model.DayOfWeek,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime
                };
                _context.Availabilities.Add(availability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
            return View(availability);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Availability availability)
        {
            if (ModelState.IsValid)
            {
                _context.Update(availability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availability);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var availability = await _context.Availabilities.FindAsync(id);
            if (availability != null)
            {
                _context.Availabilities.Remove(availability);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
