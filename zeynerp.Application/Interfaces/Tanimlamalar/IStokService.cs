using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IStokService
    {
        Task<IReadOnlyList<StokDto>> StoklarAsync();
        Task<(bool Success, string Message)> StokOlusturAsync(StokDto stokDto);
        Task<(bool Success, string Message)> StokGuncelleAsync(StokDto stokDto);
    }
}