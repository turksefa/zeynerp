using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using zeynerp.Core.Entities;
using zeynerp.Core.Exceptions;
using zeynerp.Core.Services;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public TenantService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Tenant> CreateTenantAsync(string userId)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(_configuration.GetConnectionString("DefaultConnection"));
            connectionStringBuilder.InitialCatalog = userId.Replace("-", "");

            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                ConnectionString = connectionStringBuilder.ConnectionString
            };
            await _context.Tenants.AddAsync(tenant);
            await _context.SaveChangesAsync();

            await CreateTenantDatabaseAsync(tenant.ConnectionString);

            return tenant;
        }

        public async Task<string> GetConnectionStringAsync(string userId)
        {
            var tenant = await GetTenantAsync(userId);
            return tenant.ConnectionString;
        }

        public async Task<Tenant> GetTenantAsync(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var tenant = await _context.Tenants.FindAsync(user?.TenantId);
            return tenant;
        }

        private async Task CreateTenantDatabaseAsync(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using var context = new TenantDbContext(optionsBuilder.Options);
            await context.Database.MigrateAsync();
        }
    }
}