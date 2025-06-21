using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Core.Repositories.Tanimlamalar
{
    public interface ICariRepository : IRepository<Cari>
    {
        Task<IReadOnlyList<Cari>> GetCarilerAsync();
        Task<Cari> GetCariByIdAsync(int id);
        Task DeleteCariTurlerByCariIdAsync(int id); 
    }
}