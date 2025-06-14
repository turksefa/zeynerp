using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Core.Repositories.Tanimlamalar
{
    public interface ICariTurRepository : IRepository<CariTur>
    {
        Task<CariTur> GetCariTurByIdAsync(int id);
    }
}