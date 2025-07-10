using AutoMapper;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Application.Interfaces.Tanimlamalar;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services.Tanimlamalar
{
    public class ParaBirimService : IParaBirimService
    {
        private readonly ITenantUnitOfWork _tenantUnitOfWork;
        private readonly IMapper _mapper;

        public ParaBirimService(ITenantUnitOfWork tenantUnitOfWork, IMapper mapper)
        {
            _tenantUnitOfWork = tenantUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ParaBirimDto>> GetParaBirimlerAsync() => _mapper.Map<IReadOnlyList<ParaBirimDto>>(await _tenantUnitOfWork.ParaBirimRepository.GetAllAsync());

        public async Task<(bool Success, string Message)> CreateParaBirimAsync(IReadOnlyList<ParaBirimDto> paraBirimDtos)
        {
            await _tenantUnitOfWork.ParaBirimRepository.AddRangeAsync(_mapper.Map<IReadOnlyList<ParaBirim>>(paraBirimDtos));
            return (true, "Para birimler oluşturuldu.");
        }        

        public async Task<(bool Success, string Message)> UpdateParaBirimAsync(ParaBirimDto paraBirimDto)
        {
            await _tenantUnitOfWork.ParaBirimRepository.UpdateAsync(_mapper.Map<ParaBirim>(paraBirimDto));
            return (true, "Para birimler güncelleştirildi.");
        }
    }
}