using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IAuthService AuthService { get; }

        Task SaveChangesAsync();
        // Task BeginTransactionAsync();
        // Task CommitAsync();
        // Task RollbackAsyn();
    }
}