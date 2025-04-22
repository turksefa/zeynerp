using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Services;

namespace zeynerp.Infrastructure.Data.Contexts
{
    public class TenantDbContextFactory
    {
        private readonly ITenantService _tenantService;

        public TenantDbContextFactory(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<TenantDbContext> CreateDbContextAsync(string userId)
        {
            var connectionString = await _tenantService.GetConnectionStringAsync(userId);

            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TenantDbContext(optionsBuilder.Options);
        }
    }
}