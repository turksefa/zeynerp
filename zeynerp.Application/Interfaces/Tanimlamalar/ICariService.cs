using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface ICariService
    {
        Task<IReadOnlyList<CariDto>> GetCarilerAsync();
        Task<(bool Success, string Message)> CariOlusturAsync(CariDto cariDto);
    }
}