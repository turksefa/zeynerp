using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Invitation?> GetInvitationsByEmailAsync(string email) =>
            await _context.Invitations
                .Where(i => i.Email == email)
                .FirstOrDefaultAsync();

        public async Task<IReadOnlyList<Invitation>> GetInvitationsByTenantIdAsync(Guid tenantId) =>
            await _context.Invitations
                .Where(i => i.TenantId == tenantId && i.InvitationStatus == InvitationStatus.Pending)
                .ToListAsync();
    }
}