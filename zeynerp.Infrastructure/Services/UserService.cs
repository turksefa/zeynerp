using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Infrastructure.Identity.Models;

namespace zeynerp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IReadOnlyList<UserDto>> GetUsersAsync(Guid tenantId) =>
            await _userManager.Users.Where(x => x.TenantId == tenantId).Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email
            }).ToListAsync();
    }
}