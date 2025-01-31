using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;
using zeynerp.Core.Interfaces;
using zeynerp.Infrastructure.Data;

namespace zeynerp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(bool trackChanges) => trackChanges 
            ? await _context.Products.ToListAsync() 
            : await _context.Products.AsNoTracking().ToListAsync();

        public async Task<Product> GetByIdAsync(int id, bool trackChanges) => trackChanges
                ? await _context.Products.FirstOrDefaultAsync(p => p.Id == id)
                : await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task CreateAsync(Product product) => await _context.Products.AddAsync(product);

        public void Update(Product product) => _context.Update(product);

        public void Delete(Product product) => _context.Remove(product);
    }
}