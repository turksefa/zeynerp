using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class TenantPlanService : ITenantPlanService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public TenantPlanService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public Task<IReadOnlyList<TenantPlanDto>> GetAllTenantPlansAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateTenantPlanAsync(Guid tenantId, Guid planId)
        {
            var tenantPlan = new TenantPlan
            {
                TenantId = tenantId,
                PlanId = planId,
                ExpiryDate = DateTime.Now.AddMonths(1),
                IsActive = true
            };

            await _applicationUnitOfWork.TenantPlanRepository.AddAsync(tenantPlan);
            await _applicationUnitOfWork.SaveChangesAsync();
        }        
    }
}