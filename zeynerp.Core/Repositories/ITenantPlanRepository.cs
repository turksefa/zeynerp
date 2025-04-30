using zeynerp.Core.Entities;

namespace zeynerp.Core.Repositories
{
    public interface ITenantPlanRepository : IRepository<TenantPlan>
    {
        Task<IReadOnlyList<TenantPlan>> GetPlansByTenantIdAsync(Guid tenantId);
    }
}