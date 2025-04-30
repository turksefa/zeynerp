using zeynerp.Application.DTOs;

namespace zeynerp.Web.Models
{
    public class TenantPlanViewModel
    {
        public IReadOnlyList<TenantPlanDto>? TenantPlanDtos { get; set; }
    }
}