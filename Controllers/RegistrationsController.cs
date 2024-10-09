using Event_Registration_System.data;
using Event_Registration_System.Models;
using Event_Registration_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_Registration_System.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly MainDBContext _context;
        private readonly EmailService _emailService;

        public RegistrationsController(MainDBContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<IActionResult> Register(int? eventId)
        {
            if (eventId == null) return NotFound();

            var @event = await _context.Events.FindAsync(eventId);
            if (@event == null) return NotFound();

            ViewBag.Event = @event;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();

                var @event = await _context.Events.FindAsync(registration.EventId);
                await _emailService.SendConfirmationEmail(registration.Email, registration.ParticipantName, @event!.Title);

                return RedirectToAction("Confirmation");
            }

            return View(registration);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}