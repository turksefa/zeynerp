using zeynerp.Application.DTOs.SatinalmaYonetimi;

namespace zeynerp.Application.Interfaces.SatinalmaYonetimi
{
    public interface IMalzemeTalepleriService
    {
        Task<IReadOnlyList<MalzemeTalepleriDto>> GetMalzemeTalepleriAsync();
        Task<(bool Success, string Message)> MalzemeTalepleriOlusturAsync(MalzemeTalepleriDto malzemeTalepleriDto);
    }
}