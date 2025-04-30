using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories
{
    public class TenantPlanRepository : Repository<TenantPlan>, ITenantPlanRepository
    {
        public TenantPlanRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<TenantPlan>> GetPlansByTenantIdAsync(Guid tenantId) =>
            await _context.TenantPlans
                .Where(tp => tp.TenantId == tenantId).Include(tp => tp.Plan)
                .ToListAsync();
    }
}