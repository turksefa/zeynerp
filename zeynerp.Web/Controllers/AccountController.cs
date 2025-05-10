using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.Authentication;
using zeynerp.Application.Services;
using zeynerp.Web.Models;
using zeynerp.Web.Models.Authentication;

namespace zeynerp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AccountController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public IActionResult Login([FromQuery] string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model, [FromForm] string? returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/Dashboard/Index");
            if (!ModelState.IsValid)
                return View(model);

            var (success, error) = await _authenticationService.LoginAsync(_mapper.Map<LoginDto>(model));
            if (success)
                return Redirect(returnUrl);

            ModelState.AddModelError(string.Empty, error);

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var (success, errors) = await _authenticationService.RegisterAsync(_mapper.Map<RegisterDto>(model));
            if (success)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticationService.LogoutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (success, error) = await _authenticationService.ForgotPasswordAsync(_mapper.Map<ForgotPasswordDto>(model));
                if(!success)
                    ModelState.AddModelError(string.Empty, error);
            }
            return View(model);
        }

        public IActionResult AcceptInvitation([FromQuery] Guid token)
        {
            AcceptInvitationViewModel model = new AcceptInvitationViewModel
            {
                InvitationId = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptInvitation([FromForm] AcceptInvitationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
        
            var result = await _authenticationService.AcceptInvitationAsync(_mapper.Map<InvitationAcceptDto>(model));
            if (result.Success)
                return RedirectToAction("Login");

            ModelState.AddModelError(string.Empty, result.Error);
            
            return View(model);
        }
    }
}