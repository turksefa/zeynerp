using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IKDVService
    {
        Task<IReadOnlyList<KDVDto>> GetKDVlerAsync();
        Task<(bool Success, string Message)> CreateKDVAsync(IReadOnlyList<KDVDto> kdvDtos);
        Task<(bool Success, string Message)> UpdateKDVAsync(KDVDto kdvDto);
    }
}