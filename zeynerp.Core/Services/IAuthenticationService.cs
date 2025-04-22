using zeynerp.Core.DTOs.Authentication;

namespace zeynerp.Core.Services
{
    public interface IAuthenticationService
    {
        Task<(bool Success, string[] Errors)> RegisterAsync(RegisterDto registerDto);
        Task<(bool Success, string Error)> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
        Task<(bool Success, string Error)> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<(bool Success, string Error)> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}