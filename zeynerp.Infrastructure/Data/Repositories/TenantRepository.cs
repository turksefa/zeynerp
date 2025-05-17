using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories
{
    public class TenantRepository<T> : IRepository<T> where T : class
    {
        private readonly TenantDbContextFactory _tenantDbContextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IReadOnlyList<T> entities)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}