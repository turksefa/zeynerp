using zeynerp.Core.Repositories.Tanimlamalar;

namespace zeynerp.Core.Interfaces
{
    public interface ITenantUnitOfWork
    {
        IStokGrupRepository StokGrupRepository { get; }
        Task<int> SaveChangesAsync();
    }
}