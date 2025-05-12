using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IStokGrupService
    {
        Task<IReadOnlyList<StokGrupDto>> GetStokGrupsAsync();
        Task<(bool Success, string Error)> CreateStokGrupAsync(IReadOnlyList<StokGrupDto> stokGrupDtos);
    }
}