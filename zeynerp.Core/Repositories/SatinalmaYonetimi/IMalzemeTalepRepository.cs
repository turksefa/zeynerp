using zeynerp.Core.Entities.SatinalmaYonetimi;

namespace zeynerp.Core.Repositories.SatinalmaYonetimi
{
    public interface IMalzemeTalepRepository : IRepository<MalzemeTalep>
    {
        Task<IReadOnlyList<MalzemeTalep>> GetMalzemeTaleplerAsync();
    }
}