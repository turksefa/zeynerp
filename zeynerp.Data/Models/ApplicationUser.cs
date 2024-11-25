using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace zeynerp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}