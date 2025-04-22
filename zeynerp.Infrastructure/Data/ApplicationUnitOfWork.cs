using zeynerp.Core.Interfaces;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly IPlanRepository _planRepository;
        private readonly ITenantPlanRepository _tenantPlanRepository;
        private readonly ApplicationDbContext _context;

        public ApplicationUnitOfWork(IPlanRepository planRepository, ITenantPlanRepository tenantPlanRepository, ApplicationDbContext context)
        {
            _planRepository = planRepository;
            _tenantPlanRepository = tenantPlanRepository;
            _context = context;
        }

        public IPlanRepository PlanRepository => _planRepository;

        public ITenantPlanRepository TenantPlanRepository => _tenantPlanRepository;

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}