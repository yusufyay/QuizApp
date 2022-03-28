using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Dto.auth;
using System.Threading.Tasks;

namespace QuizApp.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)  
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto data)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(data.UserName, data.Password, false, false);
                if (result.Succeeded)   return RedirectToAction("Index","Admin");

            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register( RegisterDto data)
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
