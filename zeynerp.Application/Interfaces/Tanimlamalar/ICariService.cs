using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface ICariService
    {
        Task<IReadOnlyList<CariDto>> GetCarilerAsync();
        Task<CariDto> GetCariByIdAsync(int id);
        Task<(bool Success, string Message)> CariOlusturAsync(CariDto cariDto);
        Task<(bool Success, string Message)> CariGuncelleAsync(CariDto cariDto);
    }
}