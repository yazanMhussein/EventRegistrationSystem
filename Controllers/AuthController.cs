using Event_Registration_System.Models.DTO;
using Event_Registration_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Registration_System.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUser _userService;

        public AuthController(IUser userService)
        {
            _userService = userService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Signup(RegisterUserDto data)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Register(data, ModelState);

                if (user != null)
                {

                    return RedirectToAction("Index");
                }
            }

            return View(data);
        }
    }
}
