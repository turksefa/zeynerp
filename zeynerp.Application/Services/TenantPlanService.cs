using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class TenantPlanService : ITenantPlanService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public TenantPlanService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TenantPlanDto>> GetTenantPlansByTenantIdAsync(Guid tenantId) =>
            _mapper.Map<IReadOnlyList<TenantPlanDto>>(await _applicationUnitOfWork.TenantPlanRepository.GetPlansByTenantIdAsync(tenantId));
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