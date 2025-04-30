using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Web.Extensions;
using zeynerp.Web.Models;

namespace zeynerp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IEmailSender emailSender, IMapper mapper)
        {
            _userService = userService;
            _emailSender = emailSender;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["ErrorMessages"] != null)
            {
                ModelState.AddModelError(string.Empty, TempData["ErrorMessages"].ToString());
            }
            else if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }

            var tenantId = (Guid)HttpContext.Items["TenantId"];
            var users = await _userService.GetUsersAsync(tenantId);
            var userViewModel = new UserViewModel
            {
                Users = users,
                InvitationDto = new InvitationDto()
                {
                    TenantId = tenantId
                }
            };
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendInvitation(UserViewModel userViewModel)
        {
            var result = await _userService.InvitationAsync(userViewModel.InvitationDto);
            if (!result.Success)
            {
                TempData["ErrorMessages"] = result.Error;
            }
            else
            {
                var callbackUrl = Url.Action(
                action: "Register",
                controller: "Account",
                values: new { email = userViewModel.InvitationDto.Email },
                protocol: Request.Scheme);
                await _emailSender.SendInvitationAsync(userViewModel.InvitationDto.Email, callbackUrl);

                TempData["SuccessMessage"] = $"{userViewModel.InvitationDto.Email} adresine davetiye başarıyla gönderildi.";
            }

            return RedirectToAction("Index");
        }
    }
}