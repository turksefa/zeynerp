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
        private readonly IInvitationService _invitationService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IInvitationService invitationService, IEmailSender emailSender, IMapper mapper)
        {
            _userService = userService;
            _invitationService = invitationService;
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
            var userViewModel = new UserViewModel
            {
                Users = await _userService.GetUsersAsync(tenantId),
                InvitationDtos = await _invitationService.GetInvitationsByTenantIdAsync(tenantId),
                InvitationViewModel = new InvitationViewModel()
                {
                    TenantId = tenantId
                }
            };
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendInvitation(UserViewModel model)
        {
            var result = await _invitationService.SendInvitationAsync(_mapper.Map<InvitationDto>(model.InvitationViewModel));
            if (result.Success)
            {
                var callbackUrl = Url.Action(
                action: "AcceptInvitation",
                controller: "Account",
                values: new { token = result.invitationDto.Id },
                protocol: Request.Scheme);
                await _emailSender.SendInvitationAsync(model.InvitationViewModel.Email, callbackUrl);

                TempData["SuccessMessage"] = $"{model.InvitationViewModel.Email} adresine davetiye başarıyla gönderildi.";
            }
            else
            {
                TempData["ErrorMessages"] = result.Error;
            }

            return RedirectToAction("Index");
        }
    }
}