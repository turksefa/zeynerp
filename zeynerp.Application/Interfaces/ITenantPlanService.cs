using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface ITenantPlanService
    {
        Task<IReadOnlyList<TenantPlanDto>> GetAllTenantPlansAsync();
        Task CreateTenantPlanAsync(Guid tenantId, Guid planId);
    }
}