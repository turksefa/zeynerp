using Microsoft.AspNetCore.Identity;

namespace zeynerp.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public Guid? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}