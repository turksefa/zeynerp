using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class StokOzellikService : IStokOzellikService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public StokOzellikService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StokOzellikDto>> StokOzelliklerAsync() => _mapper.Map<IReadOnlyList<StokOzellikDto>>(await _tenantUnitOfWork.StokOzellikRepository.GetAllAsync());
        
        public async Task<(bool Success, string Message)> StokOzellikOlusturAsync(IReadOnlyList<StokOzellikDto> stokOzellikDtos)
        {
            await _tenantUnitOfWork.StokOzellikRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<StokOzellik>>(stokOzellikDtos));
            return (true, "Stok özellikler oluşturuldu.");
        }

        public async Task<(bool Success, string Message)> StokOzellikGuncelleAsync(StokOzellikDto stokOzellikDto)
        {
            await _tenantUnitOfWork.StokOzellikRepository.UpdateAsync(_mapper.Map<StokOzellik>(stokOzellikDto));
            return (true, "Stok özellikler güncelleştirildi.");
        }        
    }
}