using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IStokGrupService
    {
        Task<IReadOnlyList<StokGrupDto>> GetStokGrupsAsync();
        Task<(bool Success, string Message)> CreateStokGrupAsync(IReadOnlyList<StokGrupDto> stokGrupDtos);
        Task<(bool Success, string Message)> UpdateStokGrupAsync(StokGrupDto stokGrupDto);
    }
}