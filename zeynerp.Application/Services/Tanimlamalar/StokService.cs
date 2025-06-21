using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class StokService : IStokService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public StokService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StokDto>> GetStoklarAsync() =>
            _mapper.Map<IReadOnlyList<StokDto>>(await _tenantUnitOfWork.StokRepository.GetStoklarAsync());

        public async Task<StokDto> GetStokByIdAsync(int id) => _mapper.Map<StokDto>(await _tenantUnitOfWork.StokRepository.GetStokByIdAsync(id));

        public async Task<(bool Success, string Message)> StokOlusturAsync(StokDto stokDto)
        {
            await _tenantUnitOfWork.StokRepository.AddAsync(_mapper.Map<Stok>(stokDto));
            return (true, "Stok oluşturuldu.");
        }

        public Task<(bool Success, string Message)> StokGuncelleAsync(StokDto stokDto)
        {
            throw new NotImplementedException();
        }
    }
}