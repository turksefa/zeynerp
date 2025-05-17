using zeynerp.Core.Repositories;

namespace zeynerp.Core.Interfaces
{
    public interface IApplicationUnitOfWork
    {
        IPlanRepository PlanRepository { get; }
        ITenantPlanRepository TenantPlanRepository { get; }
        IInvitationRepository InvitationRepository { get; }
    }
}