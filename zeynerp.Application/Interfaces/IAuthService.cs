using Microsoft.AspNetCore.Identity;
using zeynerp.Application.DTOs.Identity;
using zeynerp.Application.Models;

namespace zeynerp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<AuthResult> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
        Task<IdentityResult> ConfirmEmailAsync(string userId, string code);
        Task<bool> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}