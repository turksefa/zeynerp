using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories
{
    public class TenantRepository<T> : IRepository<T> where T : class
    {
        private readonly TenantDbContext _context;
        
        public TenantRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor)
        {
            _context = tenantDbContextFactory.CreateDbContextAsync(httpContextAccessor.HttpContext.Items["UserId"].ToString()).Result;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}