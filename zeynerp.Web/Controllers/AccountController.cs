using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs.Identity;
using zeynerp.Application.Interfaces;

namespace zeynerp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork.AuthService.RegisterAsync(registerDto);

                if (result.Succeeded)
                {                    
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    if(error.Code == "DuplicateUserName")
                    {
                        ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılmakta.");
                    }
                    else
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult Login([FromQuery] string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto, string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/Dashboard/Index");
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork.AuthService.LoginAsync(loginDto);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }                
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _unitOfWork.AuthService.LogoutAsync();
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // var user = await _userManager.FindByIdAsync(userId);
            // if (user == null)
            // {
            //     return RedirectToAction("Index", "Home");
            // }

            // var result = await _userManager.ConfirmEmailAsync(user, token);
            var result = await _unitOfWork.AuthService.ConfirmEmailAsync(userId, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View("Error");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordDto forgotPasswordDto)
        {
            // if (ModelState.IsValid)
            // {
            //     var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            //     if (user != null)
            //     {
            //         var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //         var resetLink = Url.Action("ResetPassword", "Account", new { token = token, email = forgotPasswordDto.Email }, Request.Scheme);

            //         await _emailSender.SendEmailAsync(forgotPasswordDto.Email, "Şifre Sıfırlama",
            //                 $"Şifrenizi sıfırlamak için lütfen şu linke tıklayın: {resetLink}");
            //     }
            // }
            return View();
        }

        public IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordDto { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto resetPasswordDto)
        {
            // if (ModelState.IsValid)
            // {
            //     var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            //     if (user != null)
            //     {
            //         var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            //         if (result.Succeeded)
            //         {
            //             return RedirectToAction("Login");
            //         }
            //         foreach (var error in result.Errors)
            //         {
            //             ModelState.AddModelError("", error.Description);
            //         }
            //     }
            // }
            return View();
        }
    }
}