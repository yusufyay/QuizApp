using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Dto.auth;
using System.Threading.Tasks;

namespace QuizApp.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto data)
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterAsync( RegisterDto data)
        {
            if(ModelState.IsValid)
            {
                var newUser = new IdentityUser
                {
                    UserName = data.UserName,
                };
                var isCreated = await _userManager.CreateAsync(newUser, data.Password); 
                
                if (isCreated.Succeeded)
                {
                    return RedirectToAction("Login","Auth");
                }
            }
            return View(data);
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
