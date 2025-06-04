using zeynerp.Application.DTOs.SatinalmaYonetimi;

namespace zeynerp.Application.Interfaces.SatinalmaYonetimi
{
    public interface IMalzemeTalepService
    {
        Task<IReadOnlyList<MalzemeTalepDto>> MalzemeTaleplerAsync();
        Task<(bool Success, string Message)> MalzemeTalepOlusturAsync(IReadOnlyList<MalzemeTalepDto> malzemeTalepDtos);
    }
}