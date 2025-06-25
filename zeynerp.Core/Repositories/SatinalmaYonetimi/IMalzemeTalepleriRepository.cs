using zeynerp.Core.Entities.SatinalmaYonetimi;

namespace zeynerp.Core.Repositories.SatinalmaYonetimi
{
    public interface IMalzemeTalepleriRepository : IRepository<MalzemeTalepleri>
    {
        Task<IReadOnlyList<MalzemeTalepleri>> GetMalzemeTalepleriAsync();
    }
}