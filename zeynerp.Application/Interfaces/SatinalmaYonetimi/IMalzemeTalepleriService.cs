using zeynerp.Application.DTOs.SatinalmaYonetimi;

namespace zeynerp.Application.Interfaces.SatinalmaYonetimi
{
    public interface IMalzemeTalepleriService
    {
        Task<IReadOnlyList<MalzemeTalepleriDto>> GetMalzemeTalepleriAsync();
        Task<IReadOnlyList<MalzemeTalepleriDto>> GetMalzemeTalepleriByCariYetkiliIdAsync(int id);
        Task<(bool Success, string Message)> MalzemeTalepleriOlusturAsync(MalzemeTalepleriDto malzemeTalepleriDto);
        Task<(bool Success, string Message)> MalzemeTalepleriGuncelleAsync(List<MalzemeTalepleriDto> malzemeTalepleriDtos);
    }
}