using Microsoft.AspNetCore.Identity;
using zeynerp.Core.Entities;

namespace zeynerp.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public Guid? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}