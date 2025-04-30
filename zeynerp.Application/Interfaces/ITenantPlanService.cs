using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface ITenantPlanService
    {
        Task<IReadOnlyList<TenantPlanDto>> GetTenantPlansByTenantIdAsync(Guid tenantId);
        Task CreateTenantPlanAsync(Guid tenantId, Guid planId);
    }
}