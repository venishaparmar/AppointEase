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
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AppointmentsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var appointments = await _context.Appointments
                                             .Where(a => a.UserId == user.Id)
                                             .ToListAsync();
            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var appointment = new Appointment
                {
                    UserId = user.Id,
                    ClientName = model.ClientName,
                    ClientEmail = model.ClientEmail,
                    AppointmentDate = model.AppointmentDate,
                    Status = "Pending"
                };
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Update(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
