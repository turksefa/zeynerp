using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class KDVService : IKDVService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public KDVService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<KDVDto>> GetKDVlerAsync() => _mapper.Map<IReadOnlyList<KDVDto>>(await _tenantUnitOfWork.KDVRepository.GetAllAsync());

        public async Task<(bool Success, string Message)> CreateKDVAsync(IReadOnlyList<KDVDto> kdvDtos)
        {
            await _tenantUnitOfWork.KDVRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<KDV>>(kdvDtos));
            return (true, "KDVler oluşturuldu.");
        }

        public async Task<(bool Success, string Message)> UpdateKDVAsync(KDVDto kdvDto)
        {
            await _tenantUnitOfWork.KDVRepository.UpdateAsync(_mapper.Map<KDV>(kdvDto));
            return (true, "KDVler güncelleştirildi.");
        }
    }
}