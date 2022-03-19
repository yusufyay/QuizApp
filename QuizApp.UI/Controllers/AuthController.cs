using Microsoft.AspNetCore.Mvc;
using QuizApp.Dto.auth;

namespace QuizApp.UI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto data)
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
