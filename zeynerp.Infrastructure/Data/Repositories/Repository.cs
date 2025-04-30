using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
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