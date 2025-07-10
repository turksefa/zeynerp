using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IParaBirimService
    {
        Task<IReadOnlyList<ParaBirimDto>> GetParaBirimlerAsync();
        Task<(bool Success, string Message)> CreateParaBirimAsync(IReadOnlyList<ParaBirimDto> paraBirimDtos);
        Task<(bool Success, string Message)> UpdateParaBirimAsync(ParaBirimDto paraBirimDto);
    }
}