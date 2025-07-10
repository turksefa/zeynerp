using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IOdemeVadeService
    {
        Task<IReadOnlyList<OdemeVadeDto>> GetOdemeVadelerAsync();
        Task<(bool Success, string Message)> CreateOdemeVadeAsync(IReadOnlyList<OdemeVadeDto> odemeVadeDtos);
        Task<(bool Success, string Message)> UpdateOdemeVadeAsync(OdemeVadeDto odemeVadeDto);
    }
}