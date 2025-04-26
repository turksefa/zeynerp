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
    }
}