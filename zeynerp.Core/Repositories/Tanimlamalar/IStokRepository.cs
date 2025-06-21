using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Core.Repositories.Tanimlamalar
{
    public interface IStokRepository : IRepository<Stok>
    {
        Task<IReadOnlyList<Stok>> GetStoklarAsync();
        Task<Stok> GetStokByIdAsync(int id);
    }
}