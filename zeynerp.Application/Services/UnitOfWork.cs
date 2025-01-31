using zeynerp.Application.Interfaces;
using zeynerp.Core.Interfaces;
using zeynerp.Infrastructure.Data;

namespace zeynerp.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(ApplicationDbContext context, IAuthService authService, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _authService = authService;
        }

        public IProductRepository ProductRepository => _productRepository;

        public IAuthService AuthService => _authService;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}