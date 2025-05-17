using zeynerp.Core.Interfaces;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly IPlanRepository _planRepository;
        private readonly ITenantPlanRepository _tenantPlanRepository;
        private readonly IInvitationRepository _invitationRepository;

        public ApplicationUnitOfWork(IPlanRepository planRepository,
            ITenantPlanRepository tenantPlanRepository,
            IInvitationRepository invitationRepository,
            ApplicationDbContext context)
        {
            _planRepository = planRepository;
            _tenantPlanRepository = tenantPlanRepository;
            _invitationRepository = invitationRepository;
        }
        
        public IPlanRepository PlanRepository => _planRepository;

        public ITenantPlanRepository TenantPlanRepository => _tenantPlanRepository;

        public IInvitationRepository InvitationRepository => _invitationRepository;
    }
}