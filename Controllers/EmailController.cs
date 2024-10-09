using Microsoft.AspNetCore.Mvc;
using Event_Registration_System.Models;
using Event_Registration_System.Services;
namespace Event_Registration_System.Controllers
{
    public class EmailController : Controller
    {
        private readonly MailjetService _mailjetService;

        public EmailController(MailjetService mailjetService)
        {

            _mailjetService = mailjetService;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Send()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailView model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _mailjetService.SendConfirmationEmail(
                    model.ToEmail,
                    model.ToName,
                    model.Subject,
                    $"<h3>{model.Subject}</h3>"

                );

                if (result)
                {
                    ViewBag.SuccessMessage = "Thank you for contacting us!";
                    return View();
                }

            }

            return View("Send", model);
        }
    }
}
