using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IInvitationService
    {
        Task<IReadOnlyList<InvitationDto>> GetInvitationsByTenantIdAsync(Guid tenantId);
        Task<InvitationDto> InvitationExistsAsync(string email);
        Task<(bool Success, string Error, InvitationDto? invitationDto)> SendInvitationAsync(InvitationDto invitationDto);
    }
}