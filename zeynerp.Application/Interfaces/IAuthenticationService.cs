using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.Authentication;

namespace zeynerp.Application.Services
{
    public interface IAuthenticationService
    {
        Task<(bool Success, string[] Errors)> RegisterAsync(RegisterDto registerDto);
        Task<(bool Success, string Error)> LoginAsync(LoginDto loginDto);
        Task LogoutAsync();
        Task<(bool Success, string Error)> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<(bool Success, string Error)> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task<(bool Success, string Error)> AcceptInvitationAsync(InvitationAcceptDto invitationAcceptDto);
    }
}