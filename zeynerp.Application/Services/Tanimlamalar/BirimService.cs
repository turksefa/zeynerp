using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class BirimService : IBirimService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public BirimService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BirimDto>> BirimlerAsync() => _mapper.Map<IReadOnlyList<BirimDto>>(await _tenantUnitOfWork.BirimRepository.GetAllAsync());
        
        public async Task<(bool Success, string Message)> BirimOlusturAsync(IReadOnlyList<BirimDto> birimDtos)
        {
            await _tenantUnitOfWork.BirimRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<Birim>>(birimDtos));
            return (true, "Birimler oluşturuldu.");
        }

        public async Task<(bool Success, string Message)> BirimGuncelleAsync(BirimDto birimDto)
        {
            await _tenantUnitOfWork.BirimRepository.UpdateAsync(_mapper.Map<Birim>(birimDto));
            return (true, "Birimler güncelleştirildi.");
        }
    }
}