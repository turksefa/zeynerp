using zeynerp.Application.DTOs.Tanimlamalar;

namespace zeynerp.Application.Interfaces.Tanimlamalar
{
    public interface IStokOzellikService
    {
        Task<IReadOnlyList<StokOzellikDto>> StokOzelliklerAsync();
        Task<(bool Success, string Message)> StokOzellikOlusturAsync(IReadOnlyList<StokOzellikDto> stokOzellikDtos);
        Task<(bool Success, string Message)> StokOzellikGuncelleAsync(StokOzellikDto stokOzellikDto);
    }
}