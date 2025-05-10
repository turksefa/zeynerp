using zeynerp.Core.Entities;

namespace zeynerp.Core.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<Invitation?> GetInvitationsByEmailAsync(string email);
        Task<IReadOnlyList<Invitation>> GetInvitationsByTenantIdAsync(Guid tenantId);
    }
}