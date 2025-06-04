using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface ICariTurService
    {
        Task<IReadOnlyList<CariTurDto>> GetCariTurlerAsync();
        Task<(bool Success, string Message)> CariTurOlusturAsync(IReadOnlyList<CariTurDto> cariTurDtos);
        Task<(bool Success, string Message)> CariTurGuncelleAsync(CariTurDto cariTurDto);
    }
}