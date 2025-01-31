using Microsoft.AspNetCore.Identity;

namespace zeynerp.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}