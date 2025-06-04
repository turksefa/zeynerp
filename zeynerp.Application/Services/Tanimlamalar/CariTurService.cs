using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class CariTurService : ICariTurService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public CariTurService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CariTurDto>> GetCariTurlerAsync() => _mapper.Map<IReadOnlyList<CariTurDto>>(await _tenantUnitOfWork.CariTurRepository.GetAllAsync());

        public async Task<(bool Success, string Message)> CariTurOlusturAsync(IReadOnlyList<CariTurDto> cariTurDtos)
        {
            await _tenantUnitOfWork.CariTurRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<CariTur>>(cariTurDtos));
            return (true, "Cari türler oluşturuldu.");
        }

        public async Task<(bool Success, string Message)> CariTurGuncelleAsync(CariTurDto cariTurDto)
        {
            await _tenantUnitOfWork.CariTurRepository.UpdateAsync(_mapper.Map<CariTur>(cariTurDto));
            return (true, $"{cariTurDto.Name} cari tür güncelleştirildi.");
        }
    }
}