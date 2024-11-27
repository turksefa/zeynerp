using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Data.Models;
using zeynerp.Web.Models;

namespace zeynerp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = registerModel.UserName, Email = registerModel.Email };
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            return View();
        }
    }
}