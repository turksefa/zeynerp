using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using zeynerp.Application.DTOs.Authentication;
using zeynerp.Application.Services;
using zeynerp.Infrastructure.Identity.Models;
using zeynerp.Infrastructure.Services;

namespace zeynerp.Infrastructure.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITenantService _tenantService;
        private readonly IEmailSender _emailSender;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITenantService tenantService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tenantService = tenantService;
            _emailSender = emailSender;
        }

        public async Task<(bool Success, string Error)> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return (false, "Kullanıcı bulunamadı.");

            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
            if (!result.Succeeded)
                return (false, "Geçersiz kullanıcı adı veya şifre.");

            return (true, string.Empty);
        }

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();

        public async Task<(bool Success, string[] Errors)> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                FullName = registerDto.FullName,
                CompanyName = registerDto.CompanyName,
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e =>
                    e.Code == "DuplicateUserName" ? "Bu e-posta adresi zaten kullanılmakta." : e.Description
                ).ToArray());

            var tenant = await _tenantService.CreateTenantAsync(user.Id);

            user.TenantId = tenant.Id;
            await _userManager.UpdateAsync(user);

            return (true, Array.Empty<string>());
        }

        public async Task<(bool Success, string Error)> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user != null && !string.IsNullOrEmpty(user.Email))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = $"http://localhost:5208/ResetPassword?email={forgotPasswordDto.Email}&token={Uri.EscapeDataString(token)}";
                await _emailSender.SendEmailAsync(user.Email, "Reset Password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
            }
            else
            {
                return (false, "Kullanıcı bulunamadı.");
            }
            return (true, string.Empty);
        }

        public Task<(bool Success, string Error)> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            throw new NotImplementedException();
        }
    }
}