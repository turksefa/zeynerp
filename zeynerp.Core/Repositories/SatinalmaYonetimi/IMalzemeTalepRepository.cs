using zeynerp.Core.Entities.SatinalmaYonetimi;

namespace zeynerp.Core.Repositories.SatinalmaYonetimi
{
    public interface IMalzemeTalepRepository : IRepository<MalzemeTalep>
    {
        Task<MalzemeTalep> GetMalzemeTalepByIdAsync(int id);
        Task<IReadOnlyList<MalzemeTalep>> GetMalzemeTaleplerAsync();
    }
}