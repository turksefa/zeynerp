using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IBirimService
    {
        Task<IReadOnlyList<BirimDto>> BirimlerAsync();
        Task<(bool Success, string Message)> BirimOlusturAsync(IReadOnlyList<BirimDto> birimDtos);
        Task<(bool Success, string Message)> BirimGuncelleAsync(BirimDto birimDto);
    }
}