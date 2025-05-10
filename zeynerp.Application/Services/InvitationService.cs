using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public InvitationService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<InvitationDto>> GetInvitationsByTenantIdAsync(Guid tenantId) =>
            _mapper.Map<IReadOnlyList<InvitationDto>>(await _applicationUnitOfWork.InvitationRepository.GetInvitationsByTenantIdAsync(tenantId));

        public async Task<InvitationDto> InvitationExistsAsync(string email) =>
            _mapper.Map<InvitationDto>(await _applicationUnitOfWork.InvitationRepository.GetInvitationsByEmailAsync(email));

        public async Task<(bool Success, string Error, InvitationDto? invitationDto)> SendInvitationAsync(InvitationDto invitationDto)
        {
            if(await InvitationExistsAsync(invitationDto.Email) != null)
                return (false, $"{invitationDto.Email} e-posta adresine zaten bir davetiye gönderildi.", null);

            var invitation = await _applicationUnitOfWork.InvitationRepository.AddAsync(_mapper.Map<Invitation>(invitationDto));
            await _applicationUnitOfWork.SaveChangesAsync();
            return (true, string.Empty, _mapper.Map<InvitationDto>(invitation));
        }
    }
}