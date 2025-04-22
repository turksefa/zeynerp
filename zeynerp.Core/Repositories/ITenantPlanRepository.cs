using zeynerp.Core.Entities;

namespace zeynerp.Core.Repositories
{
    public interface ITenantPlanRepository : IRepository<TenantPlan>
    {
        Task AssignPlanToTenantAsync(int tenantId, int planId);
    }
}